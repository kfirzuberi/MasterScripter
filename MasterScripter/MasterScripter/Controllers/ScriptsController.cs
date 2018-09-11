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

namespace MasterScripter.Controllers
{
    public class ScriptsController : Controller
    {
        private MasterScripterContext db = new MasterScripterContext();

        // GET: Scripts
        public ActionResult Index()
        {
          var grouppedScripts = db.Scripts.Include(s => s.FileType).Include(s => s.User)
                .OrderBy(script => script.Version)
                .GroupBy(script => script.Id).ToList();

          var  scripts = grouppedScripts.Select(s => s.Last()).ToList();
         
            return View(scripts.ToList());
        }

        // GET: Scripts/Details/5
        public ActionResult Details(int? id, int? version)
        {
            if (id == null || version==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id,version);
            if (script == null)
            {
                return HttpNotFound();
            }
            return View(script);
        }

        // GET: Scripts/Create
        public ActionResult Create()
        {
            ViewBag.FileTypeId = new SelectList(db.FileTypes, "Id", "Language");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName");
            return View();
        }

        // POST: Scripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Version,Content,Name,Description,UserId,CreationDate,Cost,FileTypeId")] Script script)
        {
            var scripts = db.Scripts.Include(s => s.FileType).Include(s => s.User);

            script.Id = scripts.Max(s => s.Id) + 1;
            script.Version = 1;
            script.CreationDate = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Scripts.Add(script);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FileTypeId = new SelectList(db.FileTypes, "Id", "Language", script.FileTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", script.UserId);
            return View(script);
        }

        public ActionResult GetScriptDetail(int? id, int? version)
        {
            if (id == null || version == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id, version);
            if (script == null)
            {
                return HttpNotFound();
            }
            ViewBag.FileTypeId = new SelectList(db.FileTypes, "Id", "Language", script.FileTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", script.UserId);

            return PartialView("Details", script);
        }

        // GET: Scripts/Edit/5
        public ActionResult Edit(int? id, int? version)
        {
            if (id == null || version==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id,version);
            if (script == null)
            {
                return HttpNotFound();
            }
            ViewBag.FileTypeId = new SelectList(db.FileTypes, "Id", "Language", script.FileTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", script.UserId);
            return View(script);
        }

        // POST: Scripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Version,Content,Name,Description,UserId,CreationDate,Cost,FileTypeId")] Script script)
        {
            if (ModelState.IsValid)
            {
                script.CreationDate = DateTime.Now;
                script.Version++;
                db.Scripts.Add(script);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FileTypeId = new SelectList(db.FileTypes, "Id", "Language", script.FileTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", script.UserId);
            return View(script);
        }

        // GET: Scripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            return View(script);
        }

        // POST: Scripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Script script = db.Scripts.Find(id);
            db.Scripts.Remove(script);
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
