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
    }
}