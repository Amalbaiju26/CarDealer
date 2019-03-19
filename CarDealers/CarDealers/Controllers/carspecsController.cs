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
    [Authorize(Roles ="Administrator")]
    public class carspecsController : Controller
    {
        private DbModel db = new DbModel();

        // GET: carspecs
        public ActionResult Index()
        {
            var carspecs = db.carspecs.Include(c => c.car);
            return View(carspecs.ToList());
        }

        // GET: carspecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carspec carspec = db.carspecs.Find(id);
            if (carspec == null)
            {
                return HttpNotFound();
            }
            return View(carspec);
        }

        // GET: carspecs/Create
        public ActionResult Create()
        {
            ViewBag.carno = new SelectList(db.cars, "carno", "Name");
            return View();
        }

        // POST: carspecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vpnid,Name,Description,milage,model,carno")] carspec carspec)
        {
            if (ModelState.IsValid)
            {
                db.carspecs.Add(carspec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.carno = new SelectList(db.cars, "carno", "Name", carspec.carno);
            return View(carspec);
        }

        // GET: carspecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carspec carspec = db.carspecs.Find(id);
            if (carspec == null)
            {
                return HttpNotFound();
            }
            ViewBag.carno = new SelectList(db.cars, "carno", "Name", carspec.carno);
            return View(carspec);
        }

        // POST: carspecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vpnid,Name,Description,milage,model,carno")] carspec carspec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carspec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.carno = new SelectList(db.cars, "carno", "Name", carspec.carno);
            return View(carspec);
        }

        // GET: carspecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carspec carspec = db.carspecs.Find(id);
            if (carspec == null)
            {
                return HttpNotFound();
            }
            return View(carspec);
        }

        // POST: carspecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carspec carspec = db.carspecs.Find(id);
            db.carspecs.Remove(carspec);
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
