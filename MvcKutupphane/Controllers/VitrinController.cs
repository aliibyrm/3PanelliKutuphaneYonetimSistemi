using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
using MvcKutupphane.Models.Siniflarim;
namespace MvcKutupphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TblKitap.ToList();
            cs.Deger2 = db.TblHakkimizda.ToList();
            //var degerler = db.TblKitap.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TblIletisim t)
        {
            db.TblIletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}