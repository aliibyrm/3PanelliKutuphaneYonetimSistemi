using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutupphane.Models.Entity;
namespace MvcKutupphane.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHareket.Where(x => x.IslemDurum == true).ToList();
            return View(degerler);
        }
    }
}