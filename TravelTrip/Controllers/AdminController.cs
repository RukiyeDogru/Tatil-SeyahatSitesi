using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Siniflar;
namespace TravelTrip.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]//Sayfa yüklendiği zaman çalışacak
        public ActionResult YeniBlog()
        {
            return View();//Sayfayı bize geri döndürsün

        }
        [HttpPost]//Sayfada bişey gönderdiğim zaman burdaki işlemleri
        public ActionResult YeniBlog(Blog p)//parametre türettik
        {
            c.Blogs.Add(p);//c contexten türettiğim nesnesine bağlı olarak blokların içersine ekle neyi ekleyeceksin parametreden gelen değerleri
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)//id parametresi göndericem çünkü silme işlemini idye göre yapacak
        {
            var b = c.Blogs.Find(id);//göndermiş olduğum idye ait tüm kayıtları bul
            c.Blogs.Remove(b);//context.bloglar.remove(b) den gelen değerleri listeden kaldır;
            c.SaveChanges();
            return RedirectToAction("Index");//Tekrar indexe yönlendir

        }

        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);

        }
        public ActionResult YorumSil(int id)//id parametresi göndericem çünkü silme işlemini idye göre yapacak
        {
            var b = c.Yorumlars.Find(id);//göndermiş olduğum idye ait tüm kayıtları bul
            c.Yorumlars.Remove(b);//context.yorumlar.remove(b) den gelen değerleri listeden kaldır;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");//Tekrar indexe yönlendir

        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");


        }
    }
}