using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblDuyurular.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TblDuyurular t)
        {
            db.TblDuyurular.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TblDuyurular.Find(id);
            db.TblDuyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TblDuyurular p)
        {
            var duyuru = db.TblDuyurular.Find(p.Id);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TblDuyurular t)
        {
            var duyuru = db.TblDuyurular.Find(t.Id);
            duyuru.Kategori = t.Kategori;
            duyuru.Icerik = t.Icerik;
            duyuru.Tarih = t.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}