using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20273938.Models;

namespace SinExWebApp20273938.Controllers
{
    public class PersonalShippingAccountsController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: PersonalShippingAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalShippingAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingAccountId,Building,Street,City,ProvinceCode,PostalCode,Type,CardNumber,SecurityNumber,CardholderName,ExpiryMonth,ExpiryYear,PhoneNumber,EmailAddress,AccountNumber,FirstName,LastName")] PersonalShippingAccount personalShippingAccount)
        {
            if (ModelState.IsValid)
            {
                db.ShippingAccounts.Add(personalShippingAccount);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(personalShippingAccount);
        }

        // GET: PersonalShippingAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalShippingAccount personalShippingAccount = (PersonalShippingAccount) db.ShippingAccounts.Find(id);
            if (personalShippingAccount == null)
            {
                return HttpNotFound();
            }
            return View(personalShippingAccount);
        }

        // POST: PersonalShippingAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingAccountId,Building,Street,City,ProvinceCode,PostalCode,Type,CardNumber,SecurityNumber,CardholderName,ExpiryMonth,ExpiryYear,PhoneNumber,EmailAddress,AccountNumber,FirstName,LastName")] PersonalShippingAccount personalShippingAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalShippingAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalShippingAccount);
        }

        // POST: PersonalShippingAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalShippingAccount personalShippingAccount = (PersonalShippingAccount)db.ShippingAccounts.Find(id);
            db.ShippingAccounts.Remove(personalShippingAccount);
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
