using BlogSitesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSitesi.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        Model1 ctx = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Kullanici kl)
        {
            string ka = ValidateUser(kl.KullaniciAdi, kl.Parola);

            if (!string.IsNullOrEmpty(ka))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,kl.KullaniciAdi,DateTime.Now,DateTime.Now.AddMinutes(15),true,ka,FormsAuthentication.FormsCookiePath);



                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);
              


                if (ticket.IsPersistent)
                {
                    ck.Expires =ticket.Expiration;
                }
                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(kl.KullaniciAdi, true);
                //Session["rol"] = rol;
                    
                //Response.Redirect(FormsAuthentication.GetRedirectUrl(kl.KullaniciAdi,true));
                //return RedirectToAction("Index", "Home");

            }
                 return RedirectToAction("GirisYap");

        }

        string ValidateUser(string ka,string pwd)
        {
            Kullanici kl = ctx.Kullanici.FirstOrDefault(x => x.KullaniciAdi == ka && x.Parola == pwd);
            if (kl !=null)
            {
                return kl.KullaniciAdi;
                
            }
            else
            {

                return "";
                  
            }
        }
        public ActionResult CikisYap(string redirectUrl)
        {

            FormsAuthentication.SignOut();
            return Redirect(redirectUrl);

        }



    }
}