using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TblKitap select k;
            if(!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.Ad.Contains(p));
            }
           // var kitaplar = db.TblKitap.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad+' '+i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle (TblKitap p)
        {
            var ktg = db.TblKategori.Where(k => k.Id == p.TblKategori.Id).FirstOrDefault();
            var yzr = db.TblYazar.Where(y => y.Id == p.TblYazar.Id).FirstOrDefault();
            p.TblKategori = ktg;
            p.TblYazar = yzr;
            db.TblKitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TblKitap.Find(id);
            db.TblKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TblKitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(TblKitap p)
        {
            var kitap = db.TblKitap.Find(p.Id);
            kitap.Ad = p.Ad;
            kitap.BasımYıl = p.BasımYıl;
            kitap.SayfaSayisi = p.SayfaSayisi;
            kitap.YayınEvi = p.YayınEvi;
            kitap.Durum = true;
            var ktg = db.TblKategori.Where(k => k.Id == p.TblKategori.Id).FirstOrDefault();
            var YZR = db.TblYazar.Where(y => y.Id == p.TblYazar.Id).FirstOrDefault();
            kitap.Kategori = ktg.Id;
            kitap.Yazar = YZR.Id;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}