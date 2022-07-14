using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();

            var mesajlar = db.TblMesajlar.Where(x=>x.Alıcı==uyemail.ToString()).ToList();
            return View(mesajlar);
            
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();

            var mesajlar = db.TblMesajlar.Where(x => x.Gonderen == uyemail.ToString()).ToList();
            return View(mesajlar);

        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesajlar t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.Gonderen = uyemail.ToString();
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesajlar.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesajlar");
        }
    }
}