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
    public class ElectricalAppliancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string electricalType, decimal? minPrice, decimal? maxPrice)
        {
            // Земи ги сите податоци од базата
            var electrical = db.ElectricalAppliances.AsQueryable();

            // Филтрирање по тип на облека, ако е избран од формата
            if (!string.IsNullOrEmpty(electricalType) && electricalType != "All")
            {
                electrical = electrical.Where(c => c.Type == electricalType);
            }

            // Филтрирање по минимална цена
            if (minPrice.HasValue)
            {
                electrical = electrical.Where(c => c.Price >= minPrice.Value);
            }

            // Филтрирање по максимална цена
            if (maxPrice.HasValue)
            {
                electrical = electrical.Where(c => c.Price <= maxPrice.Value);
            }

            // Подготви ги опциите за филтрирање по тип на облека
            ViewBag.ElectricalTypes = new List<string>
        {
           "All",
    "Refrigerator",
    "Washing Machine",
    "Microwave Oven",
    "Toaster",
    "Blender",
    "Coffee Maker",
    "Air Conditioner",
    "Heater",
    "Stove",
    "Dishwasher",
    "Vacuum Cleaner",
    "Iron",
    "Hair Dryer",
    "Fan",
    "Water Heater",
    "Rice Cooker",
    "Bread Maker",
    "Electric Grill",
    "Air Fryer",
    "Juicer",
    "Electric Toothbrush"
        };

            // Врати ги филтрираните податоци назад во View
            return View(electrical.ToList());
        }

        // GET: ElectricalAppliances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricalAppliance electricalAppliance = db.ElectricalAppliances.Find(id);
            if (electricalAppliance == null)
            {
                return HttpNotFound();
            }
            return View(electricalAppliance);
        }

        // GET: ElectricalAppliances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElectricalAppliances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Type,Brand,Model,Price,Condition,Description,PostedDate")] ElectricalAppliance electricalAppliance)
        {
            if (ModelState.IsValid)
            {
                db.ElectricalAppliances.Add(electricalAppliance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(electricalAppliance);
        }

        // GET: ElectricalAppliances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricalAppliance electricalAppliance = db.ElectricalAppliances.Find(id);
            if (electricalAppliance == null)
            {
                return HttpNotFound();
            }
            return View(electricalAppliance);
        }

        // POST: ElectricalAppliances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Type,Brand,Model,Price,Condition,Description,PostedDate")] ElectricalAppliance electricalAppliance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electricalAppliance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(electricalAppliance);
        }

        // GET: ElectricalAppliances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricalAppliance electricalAppliance = db.ElectricalAppliances.Find(id);
            if (electricalAppliance == null)
            {
                return HttpNotFound();
            }
            return View(electricalAppliance);
        }

        // POST: ElectricalAppliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ElectricalAppliance electricalAppliance = db.ElectricalAppliances.Find(id);
            db.ElectricalAppliances.Remove(electricalAppliance);
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
