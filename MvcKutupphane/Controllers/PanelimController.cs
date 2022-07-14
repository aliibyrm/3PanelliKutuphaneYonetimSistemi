using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutupphane.Models.Entity;

//using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TblUyeler.FirstOrDefault(z => z.Mail == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TblUyeler p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TblUyeler.FirstOrDefault(x => x.Mail == kullanici);
            uye.Sifre = p.Sifre;
            uye.Ad = p.Ad;
            uye.Fotograf = p.Fotograf;
            uye.Okul = p.Okul;
            uye.KullaniciAdi = p.KullaniciAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
             var kullanici = (string)Session["Mail"];
             var id = db.TblUyeler.Where(x => x.Mail == kullanici.ToString()).Select(z => z.Id).FirstOrDefault();
             var degerler = db.TblHareket.Where(x => x.Uye == id).ToList();
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TblDuyurular.ToList();
            return View(duyurulistesi);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }

    }
}