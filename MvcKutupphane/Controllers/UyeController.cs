﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
using PagedList.Mvc;
using PagedList;

namespace MvcKutupphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(/*int sayfa=1*/)
        {
            var degerler = db.TblUyeler.ToList();
            //var degerler = db.TblUyeler.ToList()/*.ToPagedList(sayfa, 3)*/;
            return View(degerler);
            
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TblUyeler.Find(id);
            db.TblUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TblUyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TblUyeler p)
        {
            var uye = db.TblUyeler.Find(p.Id);
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.Mail = p.Mail;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Sifre = p.Sifre;
            uye.Okul = p.Okul;
            uye.Telefon = p.Telefon;
            uye.Fotograf = p.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgcms = db.TblHareket.Where(x => x.Uye == id).ToList();
            var uyekit = db.TblUyeler.Where(y => y.Id == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgcms);
        }
    }
}