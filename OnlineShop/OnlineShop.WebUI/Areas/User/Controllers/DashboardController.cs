using OnlineShop.Entities;
using OnlineShop.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.WebUI.Areas.User.Models;

namespace OnlineShop.WebUI.Areas.User.Controllers
{
    public class DashboardController : Controller
    {
        private IRepository _repository;
        private const int PageSize = 6;

        public DashboardController(IRepository repoParam)
        {
            _repository = repoParam;
        }

        // GET: User/Dashboard
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategories()
        {
            var categories = _repository.Get<Category>().Select(c => c.Name);
            return Json(categories , JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducts(int currentPage = 1, string category = "All", int minChoiceCost = 0, int maxChoiceCost = int.MaxValue, string searchedTitle = "")
        {
            maxChoiceCost = maxChoiceCost == 0 ? int.MaxValue : maxChoiceCost;
            var products = (category == "All" ?
                _repository.Get<Product>(p => p.Cost >= minChoiceCost
                    && p.Cost <= maxChoiceCost
                    && p.Title.ToLower().Contains(searchedTitle.ToLower()),
                    p => p.Category,
                    p => p.Comments)
                :
                _repository.Get<Product>(p => p.Category.Name == category
                    && p.Cost >= minChoiceCost
                    && p.Cost <= maxChoiceCost
                    && p.Title.ToLower().Contains(searchedTitle.ToLower()),
                    p => p.Category,
                    p => p.Comments)).Select(p => new
                {
                    Id = p.Id,
                    ShowComments = false,
                    Title = p.Title,
                    Cost = p.Cost,
                    Quantity = p.Quantity,
                    IsAvailable = p.IsAvailable,
                    ProdCategory = p.Category.Name,
                    Commentaries = p.Comments.Select(c => new
                    {
                        CommentText = c.Text,
                        ClientName = _repository.GetSingle<Client>(cl=> cl.Id == c.ClientId).FirstName + " " + _repository.GetSingle<Client>(cl => cl.Id == c.ClientId).LastName
                    })
                });
            int pages = products.Count() / PageSize;
            int count = products.Count() % PageSize == 0 ? pages : ++pages;
            decimal maxCost = products.Count() != 0 ? products.Max(p => p.Cost) : 0;

            products = products.Skip((currentPage - 1) * PageSize).Take(PageSize);

            return Json(new { products = products, allPages = count, maxCost = maxCost }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddComment(int id, string comment)
        {
            var newComment = _repository.Insert<Comment>(new Comment
            {
                Text = comment,
                ProductId = id,
                ClientId = 1
            });

            var result = new
            {
                CommentText = newComment.Text,
                ClientName = _repository.GetSingle<Client>(cl => cl.Id == newComment.ClientId).FirstName + " " + _repository.GetSingle<Client>(cl => cl.Id == newComment.ClientId).LastName
            };
            return Json(result);
        }
    }
}