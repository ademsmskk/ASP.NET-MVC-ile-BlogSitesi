using BlogSitesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSitesi.Controllers
{
    [Authorize]
    public class MakaleController : Controller
    {
        // GET: Makale
        Model1 ctx = new Model1();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Detay(int id)
        {
            var data = ctx.Makale.FirstOrDefault(x => x.MakaleId == id);
            return View(data);

        }
        [Authorize(Roles ="Admin")]
        public ActionResult MakaleEkle()
        {
             
            return View();
        }


    }
}