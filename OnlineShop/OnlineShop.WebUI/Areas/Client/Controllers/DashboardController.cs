using OnlineShop.Entities;
using OnlineShop.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.WebUI.Areas.Client.Controllers
{
    public class DashboardController : Controller
    {
        private IRepository _repository;
        private const int PageSize = 10;

        public DashboardController(IRepository repoParam)
        {
            _repository = repoParam;
        }

        // GET: Client/Dashboard
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

        public JsonResult GetProducts(int currentPage = 1, string category = "All")
        {
            var products = category == "All" ? _repository.Get<Product>().Select(p => new
            {
                Title = p.Title,
                Cost = p.Cost,
                Quantity = p.Quantity,
                IsAvailable = p.IsAvailable
            }) : _repository.Get<Product>(p => p.Category.Name == category).Select(p => new
            {
                Title = p.Title,
                Cost = p.Cost,
                Quantity = p.Quantity,
                IsAvailable = p.IsAvailable
            });

            int count = products.Count() / PageSize;

            products = products.Skip((currentPage - 1) * PageSize).Take(PageSize);

            return Json(new { products = products, allPages = count }, JsonRequestBehavior.AllowGet);
        }
    }
}