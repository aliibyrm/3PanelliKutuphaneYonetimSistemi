﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
using System.Web.Security;
namespace MvcKutupphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TblUyeler p)
        {
            var bilgiler = db.TblUyeler.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                //TempData["ID"] = bilgiler.Id.ToString();
                //TempData["Ad"] = bilgiler.Ad.ToString();
                //TempData["Soyad"] = bilgiler.Soyad.ToString();
                //TempData["KullanıcıAdı"] = bilgiler.KullaniciAdi.ToString();
                //TempData["Sifre"] = bilgiler.Sifre.ToString();
                //TempData["Okul"] = bilgiler.Okul.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}