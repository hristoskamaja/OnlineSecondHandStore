using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Secondhand_Store.Models;

namespace Online_Secondhand_Store.Controllers
{
    public class ClothingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

 

        public ActionResult Index(string clothingType, decimal? minPrice, decimal? maxPrice)
        {
            // Земи ги сите податоци од базата
            var clothings = db.Clothings.AsQueryable();

            // Филтрирање по тип на облека, ако е избран од формата
            if (!string.IsNullOrEmpty(clothingType) && clothingType != "All")
            {
                clothings = clothings.Where(c => c.Type == clothingType);
            }

            // Филтрирање по минимална цена
            if (minPrice.HasValue)
            {
                clothings = clothings.Where(c => c.Price >= minPrice.Value);
            }

            // Филтрирање по максимална цена
            if (maxPrice.HasValue)
            {
                clothings = clothings.Where(c => c.Price <= maxPrice.Value);
            }

            // Подготви ги опциите за филтрирање по тип на облека
            ViewBag.ClothingTypes = new List<string>
        {
            "All",
            "Jeans",
            "Shirt",
            "Jacket",
            "Dress",
            "Sweater",
            "T-shirt",
            "Shorts",
            "Pants",
            "Cardigan",
            "Shoes",
            "Blouse",
            "Skirt",
            "Coat",
            "Socks",
            "Scarf",
            "Hat",
            "Gloves",
            "Belt",
            "Underwear",
            "Suit",
            "Tie",
            "Boots",
            "Sandals",
            "Cap"
        };

            // Врати ги филтрираните податоци назад во View
            return View(clothings.ToList());
        }




        // GET: Clothings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // GET: Clothings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clothings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Type,Size,Color,Material,Price,Condition,Description,PostedDate")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Clothings.Add(clothing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clothing);
        }


        // GET: Clothings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // POST: Clothings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Type,Size,Color,Material,Price,Condition,Description,PostedDate")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clothing);
        }

        // GET: Clothings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // POST: Clothings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clothing clothing = db.Clothings.Find(id);
            db.Clothings.Remove(clothing);
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
