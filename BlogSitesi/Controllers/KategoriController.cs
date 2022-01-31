using BlogSitesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    
    public class KategoriController : Controller
    {
        Model1 ctx = new Model1();
        // GET: Kategori
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult KategoriWidget()
        {
            return PartialView(ctx.Kategori.ToList());
        }


        public ActionResult MakaleListele(int id)
        {

            var data = ctx.Makale.Where(x => x.KategoriID == id).ToList();
            return View("MakaleListeleWidget", data);

        }

    }
}