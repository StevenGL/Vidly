using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersfortextController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customersfortext
        public ActionResult Index()
        {
            var customerses = db.Customerses.Include(c => c.MembershipType);
            return View(customerses.ToList());
        }

        // GET: Customersfortext/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customerses.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customersfortext/Create
        public ActionResult Create()
        {
            ViewBag.MemberShipTypeId = new SelectList(db.MembershipTypes, "Id", "TypeOfMembership");
            return View();
        }

        // POST: Customersfortext/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsSubcribedToNewsLetter,MemberShipTypeId,Birthday")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Customerses.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberShipTypeId = new SelectList(db.MembershipTypes, "Id", "TypeOfMembership", customers.MemberShipTypeId);
            return View(customers);
        }

        // GET: Customersfortext/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customerses.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberShipTypeId = new SelectList(db.MembershipTypes, "Id", "TypeOfMembership", customers.MemberShipTypeId);
            return View(customers);
        }

        // POST: Customersfortext/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsSubcribedToNewsLetter,MemberShipTypeId,Birthday")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberShipTypeId = new SelectList(db.MembershipTypes, "Id", "TypeOfMembership", customers.MemberShipTypeId);
            return View(customers);
        }

        // GET: Customersfortext/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customerses.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customersfortext/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customerses.Find(id);
            db.Customerses.Remove(customers);
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
