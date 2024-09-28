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
    public class ComputerAndITEquipmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string compType, decimal? minPrice, decimal? maxPrice)
        {
            // Земи ги сите податоци од базата
            var comp = db.ComputerAndITEquipments.AsQueryable();

            // Филтрирање по тип на облека, ако е избран од формата
            if (!string.IsNullOrEmpty(compType) && compType != "All")
            {
                comp = comp.Where(c => c.Type == compType);
            }

            // Филтрирање по минимална цена
            if (minPrice.HasValue)
            {
                comp = comp.Where(c => c.Price >= minPrice.Value);
            }

            // Филтрирање по максимална цена
            if (maxPrice.HasValue)
            {
                comp = comp.Where(c => c.Price <= maxPrice.Value);
            }

            // Подготви ги опциите за филтрирање по тип на облека
            ViewBag.CompTypes = new List<string>
{
    "All",
    "Laptop",
    "Desktop Computer",
    "Monitor",
    "Keyboard",
    "Mouse",
    "Headphones",
    "Speakers",
    "Printer",
    "Scanner",
    "Microphone",
    "Smartphone",
    "Tablet",

};


            // Врати ги филтрираните податоци назад во View
            return View(comp.ToList());
        }

        // GET: ComputerAndITEquipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerAndITEquipment computerAndITEquipment = db.ComputerAndITEquipments.Find(id);
            if (computerAndITEquipment == null)
            {
                return HttpNotFound();
            }
            return View(computerAndITEquipment);
        }

        // GET: ComputerAndITEquipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComputerAndITEquipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Type,Brand,Model,Specifications,Price,Condition,Description,PostedDate")] ComputerAndITEquipment computerAndITEquipment)
        {
            if (ModelState.IsValid)
            {
                db.ComputerAndITEquipments.Add(computerAndITEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(computerAndITEquipment);
        }

        // GET: ComputerAndITEquipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerAndITEquipment computerAndITEquipment = db.ComputerAndITEquipments.Find(id);
            if (computerAndITEquipment == null)
            {
                return HttpNotFound();
            }
            return View(computerAndITEquipment);
        }

        // POST: ComputerAndITEquipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Type,Brand,Model,Specifications,Price,Condition,Description,PostedDate")] ComputerAndITEquipment computerAndITEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computerAndITEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computerAndITEquipment);
        }

        // GET: ComputerAndITEquipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerAndITEquipment computerAndITEquipment = db.ComputerAndITEquipments.Find(id);
            if (computerAndITEquipment == null)
            {
                return HttpNotFound();
            }
            return View(computerAndITEquipment);
        }

        // POST: ComputerAndITEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComputerAndITEquipment computerAndITEquipment = db.ComputerAndITEquipments.Find(id);
            db.ComputerAndITEquipments.Remove(computerAndITEquipment);
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
