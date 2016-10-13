using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fortune_teller_mvc.Models;

namespace fortune_teller_mvc.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            if (customer.Age % 2 == 0)
            {
                ViewBag.retire = " will retire in 90 years";
            }
            else
            {
                ViewBag.retire = " will retire in 25 years";
            }
            if (customer.NumberOfSiblings == 0)
            {
                ViewBag.vacationHome = "a vacation home in Italy";
            }
            else if (customer.NumberOfSiblings == 1)
            {
                ViewBag.vacationHome = "a vacation home in Fiji";
            }
            else if (customer.NumberOfSiblings == 2)
            {
                ViewBag.vacationHome = "a vacation home in France";
            }
            else if (customer.NumberOfSiblings == 3)
            {
                ViewBag.vacationHome = "a vacation home in Long Island";
            }
            else if (customer.NumberOfSiblings > 3)
            {
                ViewBag.vacationHome = "a vacation home in the Bahamas";
            }
            else if (customer.NumberOfSiblings < 0)
            {
                ViewBag.vacationHome = "a vacation home in Siberia";
            }
            if (customer.FavoriteColor.ToLower() == "red")
            {
                ViewBag.vehicle = "a horse.";
            }
            else if (customer.FavoriteColor.ToLower() == "orange")
            {
                ViewBag.vehicle = "a helicopter.";
            }
            else if (customer.FavoriteColor.ToLower() == "yellow")
            {
                ViewBag.vehicle = "a donkey.";
            }
            else if (customer.FavoriteColor.ToLower() == "green")
            {
                ViewBag.vehicle = "a car.";
            }
            else if (customer.FavoriteColor.ToLower() == "blue")
            {
                ViewBag.vehicle = "a motorcycle.";
            }
            else if (customer.FavoriteColor.ToLower() == "indigo")
            {
                ViewBag.vehicle = "a boat.";
            }
            else if (customer.FavoriteColor.ToLower() == "violet")
            {
                ViewBag.vehicle = "a plane.";
            }
            if (customer.BirthMonth >= 1 && customer.BirthMonth <= 4)
            {
                ViewBag.money = " with $100000 in the bank, ";
            }
            else if (customer.BirthMonth >= 5 && customer.BirthMonth <= 8)
            {
                ViewBag.money = " with $200000 in the bank, ";
            }
            else if (customer.BirthMonth >= 9 && customer.BirthMonth <= 12)
            {
                ViewBag.money = " with $300000 in the bank, ";
            }
            else if (customer.BirthMonth <= 0 || customer.BirthMonth >= 12)
            {
                ViewBag.money = " with $0.00 in the bank, ";
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
