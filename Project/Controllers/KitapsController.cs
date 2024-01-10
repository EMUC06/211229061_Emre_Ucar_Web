using Project.Models.Data;
using Project.Models.DataContext;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Project.Controllers
{
	public class KitapsController : Controller
	{
		private ProjeDbContext db = new ProjeDbContext();

		public ActionResult Index()
		{
			return View(db.Kitaps.ToList());
		}

		public ActionResult PopulerKitap()
		{
			return View(db.Kitaps.Where(b => b.PopulerMi == true).ToList());
		}

		public class YasAraligi
		{
			public int Baslangic { get; set; }
			public int Bitis { get; set; }
		}

		public ActionResult KitapTavsiye()
		{
			var gruplanmisKitaplar = db.Kitaps
				.GroupBy(kitap => new YasAraligi { Baslangic = kitap.YasAraligiBaslangic, Bitis = kitap.YasAraligiBitis })
				.ToDictionary(grup => grup.Key, grup => grup.ToList());

			return View(gruplanmisKitaplar);
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kitap kitap = db.Kitaps.Find(id);
			if (kitap == null)
			{
				return HttpNotFound();
			}
			return View(kitap);
		}


		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create([Bind(Include = "Id,Ad,YasAraligiBaslangic,YasAraligiBitis,PopulerMi")] Kitap kitap)
		{
			if (ModelState.IsValid)
			{
				db.Kitaps.Add(kitap);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(kitap);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kitap kitap = db.Kitaps.Find(id);
			if (kitap == null)
			{
				return HttpNotFound();
			}
			return View(kitap);
		}

		[HttpPost]
		public ActionResult Edit([Bind(Include = "Id,Ad,YasAraligiBaslangic,YasAraligiBitis,PopulerMi")] Kitap kitap)
		{
			if (ModelState.IsValid)
			{
				db.Entry(kitap).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(kitap);
		}


		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kitap kitap = db.Kitaps.Find(id);
			if (kitap == null)
			{
				return HttpNotFound();
			}
			return View(kitap);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Kitap kitap = db.Kitaps.Find(id);
			db.Kitaps.Remove(kitap);
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
