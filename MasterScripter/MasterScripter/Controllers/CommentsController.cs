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
    public class CommentsController : Controller
    {
        private MasterScripterContext db = new MasterScripterContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Execution).Include(c => c.User);

            ViewBag.CurrentUser = db.Users.FirstOrDefault(u => u.Email.Equals(User.Identity.Name));
            return View(comments.ToList());
        }

        public ActionResult CommentsByExecution(int executionid)
        {
            var comments = db.Comments.Where(c=>c.ExecutionId==executionid).Include(c => c.Execution).Include(c => c.User);
            ViewBag.CurrentUser = db.Users.FirstOrDefault(u => u.Email.Equals(User.Identity.Name));

            return PartialView("Index",comments.ToList());
        }

        public ActionResult GetConversion(int executionid)
        {
            ViewBag.Executionid = executionid;
            return PartialView("Conversion");
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.ExecutionId = new SelectList(db.Executions, "Id", "Id");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,CreationDate,UserId,ExecutionId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Email.Equals(User.Identity.Name));

                comment.UserId = user.Id;
                comment.CreationDate = DateTime.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
            }

            return Content("OK");
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExecutionId = new SelectList(db.Executions, "Id", "MachineIP", comment.ExecutionId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", comment.UserId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,CreationDate,UserId,ExecutionId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExecutionId = new SelectList(db.Executions, "Id", "MachineIP", comment.ExecutionId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
