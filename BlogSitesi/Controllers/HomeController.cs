using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    using BlogSitesi.App_Classes;
    using Models.Entity;
    public class HomeController : Controller
    {
        
        Model1 ctx = new Model1();
        
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
      public ActionResult MakaleListele(int id)
        {
            var data = ctx.Makale.ToList();

            return View("MakaleListeleWidget",data);
        }

        public PartialViewResult PopulerMakalelerWidget()
        {
            var model = ctx.Makale.OrderByDescending(x => x.EklenmeTarihi).Take(3).ToList();
            return PartialView(model);
        }

    }
}