using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterScripter.DAL.Models;
using MasterScripter.Models;
using Microsoft.AspNet.Identity;

namespace MasterScripter.Controllers
{
   // [Authorize]
    public class MachinesController : Controller
    {
        private MasterScripterContext db = new MasterScripterContext();

        // GET: Machines
        public ActionResult Index()
        {
            var machines = db.Machines.Include(m => m.Company).Include(m => m.Country);
         var name =   User.Identity.GetUserName();
            return View(machines.ToList());
        }

        // GET: Machines/Details/5
        public ActionResult Details(string ip, int? vlan)
        {
            if (string.IsNullOrEmpty(ip) || vlan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(ip, vlan);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        public ActionResult GetMachineDetails(string ip, int? vlan)
        {
            if (string.IsNullOrEmpty(ip) || vlan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(ip, vlan);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", machine);
        }

        // GET: Machines/Create
        public ActionResult Create()
        {
            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IP,VLan,IsDeleted,CompanyCode,CreationDate,CountryId")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Machines.Add(machine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name", machine.CompanyCode);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", machine.CountryId);
            return View(machine);
        }

        // GET: Machines/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name", machine.CompanyCode);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", machine.CountryId);
            return View(machine);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IP,VLan,IsDeleted,CompanyCode,CreationDate,CountryId")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name", machine.CompanyCode);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", machine.CountryId);
            return View(machine);
        }

        // GET: Machines/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Machine machine = db.Machines.Find(id);
            db.Machines.Remove(machine);
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
