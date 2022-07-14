using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TblUyeler p)
        {
            if(!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}