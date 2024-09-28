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
    public class FurnituresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string furnitureType, decimal? minPrice, decimal? maxPrice)
        {
            // Земи ги сите податоци од базата
            var furniture = db.Furnitures.AsQueryable();

            // Филтрирање по тип на облека, ако е избран од формата
            if (!string.IsNullOrEmpty(furnitureType) && furnitureType != "All")
            {
                furniture = furniture.Where(c => c.Type == furnitureType);
            }

            // Филтрирање по минимална цена
            if (minPrice.HasValue)
            {
                furniture = furniture.Where(c => c.Price >= minPrice.Value);
            }

            // Филтрирање по максимална цена
            if (maxPrice.HasValue)
            {
                furniture = furniture.Where(c => c.Price <= maxPrice.Value);
            }

            // Подготви ги опциите за филтрирање по тип на облека
            ViewBag.FurnitureTypes = new List<string>
        {
           "All",
    "Sofa",
    "Armchair",
    "Coffee Table",
    "Dining Table",
    "Chairs",
    "Bed",
    "Wardrobe",
    "Bookshelf",
    "Desk",
    "Office Chair",
    "Nightstand"
        };

            // Врати ги филтрираните податоци назад во View
            return View(furniture.ToList());
        }


        // GET: Furnitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furnitures.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // GET: Furnitures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Furnitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Type,Material,Dimensions,Price,Condition,Description,PostedDate")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                db.Furnitures.Add(furniture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(furniture);
        }

        // GET: Furnitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furnitures.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // POST: Furnitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Type,Material,Dimensions,Price,Condition,Description,PostedDate")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(furniture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(furniture);
        }

        // GET: Furnitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furnitures.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // POST: Furnitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Furniture furniture = db.Furnitures.Find(id);
            db.Furnitures.Remove(furniture);
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
