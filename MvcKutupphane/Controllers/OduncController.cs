using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHareket.Where(x => x.IslemDurum == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TblUyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad+" "+x.Soyad,
                                               Value = x.Id.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from y in db.TblKitap.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.Ad,
                                               Value = y.Id.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from z in db.TblPersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.Personel,
                                               Value = z.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TblHareket p)
        {
            var d1 = db.TblUyeler.Where(x => x.Id == p.TblUyeler.Id).FirstOrDefault();
            var d2 = db.TblKitap.Where(y => y.Id == p.TblKitap.Id).FirstOrDefault();
            var d3 = db.TblPersonel.Where(z => z.Id == p.TblPersonel.Id).FirstOrDefault();
            p.TblUyeler = d1;
            p.TblKitap = d2;
            p.TblPersonel = d3;
            db.TblHareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Odunciade(TblHareket p)
        {
            var odn = db.TblHareket.Find(p.Id);
            DateTime d1 = DateTime.Parse(odn.IadeTarihi.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade", odn);
        }
        public ActionResult OduncGuncelle(TblHareket p)
        {
            var hrk = db.TblHareket.Find(p.Id);
            hrk.UyeGetirTarih = p.UyeGetirTarih;
            hrk.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}