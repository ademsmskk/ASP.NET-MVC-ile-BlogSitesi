using BlogSitesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class EtiketController : Controller
    {
        Model1 ctx = new Model1();
        // GET: Etiket
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult EtiketWidget()
        {
            return PartialView(ctx.Etiket.ToList());
        }

        public ActionResult MakaleListele(int id)
        {

            var data = ctx.Makale.Where(x => x.Etiket.Any(y => y.EtiketId == id)).ToList();
            return View("MakaleWidget", data);

        }

    }
}