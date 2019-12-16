using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnlineVer2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
            // goi thanH VIEW  khong goi thanh trang dc

        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
          
          
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
          
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Slide()
        {
            return PartialView();
        }

        
    }
}