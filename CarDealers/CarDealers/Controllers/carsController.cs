using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealers.Models;

namespace CarDealers.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class carsController : Controller
    {
       // private DbModel db = new DbModel();
         
        IMockCars db;

       //constructor
       //defaulf 
       public carsController(IMockCars @object)
        {
            this.db = new IDataCars();
        }
        public carsController(IDataCars mockDb)
        {
            this.db = mockDb;
        }

        public carsController()
        {
        }

        [AllowAnonymous]
        // GET: cars
        public ActionResult Index()
        {
            return View("index",db.Cars.ToList());
        }

        // GET: cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // car car = db.Cars.Find(id);
            car car = db.Cars.SingleOrDefault(c => c.carno == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: cars/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carno,Name,price,color")] car car)
        {
            if (ModelState.IsValid)
            {
                // db.Cars.Add(car);
                //db.SaveChanges();
                db.Save(car);
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: cars/Edit/5
        public ActionResult Edit(car car, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //car car = db.Cars.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(id );
        }

        // POST: cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carno,Name,price,color")] car car)
        {
            if (ModelState.IsValid)
            {
                //  db.Entry(car).State = EntityState.Modified;
                // db.SaveChanges();
                db.Save(car);
                return RedirectToAction("Index");
            }
            return View("Edit",car);
        }

        // GET: cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  car car = db.Cars.Find(id);
            car car = db.Cars.SingleOrDefault(c => c.carno == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //car car = db.Cars.Find(id);
            car car = db.Cars.SingleOrDefault(c => c.carno == id);
            // db.Cars.Remove(car);
            //db.SaveChanges();
            db.Delete(car);
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
