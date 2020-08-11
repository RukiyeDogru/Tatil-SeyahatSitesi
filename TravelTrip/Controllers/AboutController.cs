using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        Context c = new Context();//Context sınıfından c isimli bi nesne ürettim
        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList();//bu c sayesindede contexte bağlı sınıflarımız içinden hakkımızdas tablosuna ulaşıp bu tabloyu listele dedim


            return View(degerler);
        }
    }
}