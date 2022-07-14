﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblKategori.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TblKategori p)
        {
            db.TblKategori.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TblKategori.Find(id);
            // db.TblKategori.Remove(kategori);
            kategori.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TblKategori.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGuncelle(TblKategori p)
        {
            var ktg = db.TblKategori.Find(p.Id);
            ktg.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}