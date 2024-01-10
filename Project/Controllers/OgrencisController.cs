using Project.Models.Data;
using Project.Models.DataContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Project.Controllers
{
	public class OgrencisController : Controller
    {
        private ProjeDbContext db = new ProjeDbContext();

        public ActionResult Index()
        {
            return View(db.Ogrencis.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrencis.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create([Bind(Include = "Id,Ad,SoyAd,Yas")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Ogrencis.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenci);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrencis.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }


        [HttpPost]

        public ActionResult Edit([Bind(Include = "Id,Ad,SoyAd,Yas")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrencis.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }


        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = db.Ogrencis.Find(id);
            db.Ogrencis.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
