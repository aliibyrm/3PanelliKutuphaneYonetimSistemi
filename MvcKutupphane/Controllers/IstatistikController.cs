using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers

{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.TblUyeler.Count();
            var deger2 = db.TblKitap.Count();
            var deger3 = db.TblKitap.Where(x=>x.Durum==false).Count();
            var deger4 = db.TblCezalar.Sum(x=>x.Para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if(dosya.ContentLength>0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);

            }
            return RedirectToAction("Galeri");          
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.TblKitap.Count();
            var deger2 = db.TblUyeler.Count();
            var deger3 = db.TblCezalar.Sum(x=>x.Para);
            var deger4 = db.TblKitap.Where(x=>x.Durum==false).Count();
            var deger5 = db.TblKategori.Count();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.TblKitap.GroupBy(x => x.YayınEvi).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var deger11 = db.TblIletisim.Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr11 = deger11;
            return View();
        }
    }
}