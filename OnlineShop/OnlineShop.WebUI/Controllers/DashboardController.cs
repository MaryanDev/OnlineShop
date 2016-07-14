using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Entities;
using OnlineShop.Repositories.Abstract;
using OnlineShop.Repositories.Concrete;

namespace OnlineShop.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}