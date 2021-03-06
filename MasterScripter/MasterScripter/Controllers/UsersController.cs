﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterScripter.BL.Utils;
using MasterScripter.DAL.Models;
using MasterScripter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MasterScripter.Controllers
{
    [Authorize]
    [ConnectedUserFilterAttribute]

    public class UsersController : Controller
    {
        private MasterScripterContext db = new MasterScripterContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Company);
            return View(users.ToList());
        }

        public ActionResult GetUnconnectedUsers()
        {
            // Gel all Users from our DB.
            var dbusers = db.Users.Include(u => u.Company).ToList();

            // Get all registered users (Users from the template DB).
            var users = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().Users.ToList(); 

            // Get the new Users (unconnected) -
            // Filter the Users that exist in the template DB and not exist in our DB (Filter by email)
            // And create a new list of Users (our model)
            var unconnectedUserst = users
                .Where(u=>!dbusers.Any(dbu=>dbu.Email.ToLower().Equals(u.Email.ToLower()))).ToList() // emails that don't exist
                .ConvertAll(u=>new User() // convert to our User object model
                {
                    FullName = u.UserName,
                    Email = u.Email,
                    IsDeleted = true
                });

            // Send to the View a "Flag" that indicates that this is a Unconected users list
            ViewBag.IsUnconnectedUsers = true;

            // Return the Indec view BUT(!!) send the genreated list
            return View("Index", unconnectedUserst.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name");
            return View();
        }

        // GET: Users/Create
        public ActionResult Connect(string username, string email) // same as Create, but send known data.
        {
            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name");
            ViewBag.UserName = username;
            ViewBag.Email = email;

            return View("Create");
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Email,Role,IsDeleted,CompanyCode,CreationDate")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CreationDate = DateTime.Now;
                user.IsDeleted = false;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name", user.CompanyCode);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name", user.CompanyCode);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,Role,IsDeleted,CompanyCode,CreationDate")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyCode = new SelectList(db.Companies, "Code", "Name", user.CompanyCode);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
