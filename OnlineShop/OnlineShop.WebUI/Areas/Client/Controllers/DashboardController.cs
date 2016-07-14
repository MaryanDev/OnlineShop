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
        public ActionResult Index()
        {
            var model = _repository.Get<Category>();
            return View(model);
        }
    }
}