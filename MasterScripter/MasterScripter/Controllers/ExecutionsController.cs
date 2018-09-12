using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterScripter.DAL.Models;
using MasterScripter.Models;

namespace MasterScripter.Controllers
{
    public class ExecutionsController : Controller
    {
        private MasterScripterContext db = new MasterScripterContext();

        // GET: Executions
        public ActionResult Index()
        {
            var executions = db.Executions.Include(e => e.Machine).Include(e => e.Reason).Include(e => e.User);
            return View(executions.ToList());
        }

        // GET: Executions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Execution execution = db.Executions.Find(id);
            if (execution == null)
            {
                return HttpNotFound();
            }
            return View(execution);
        }

        // GET: Executions/Create
        public ActionResult Create()
        {
            ViewBag.Machines =  db.Machines;
            ViewBag.ReasonId = new SelectList(db.Reasons, "Id", "ReasonName");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName");
            return View();
        }
        public ActionResult GetExecutionDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Execution execution = db.Executions.Find(id);
            if (execution == null)
            {
                return HttpNotFound();
            }
        
            return PartialView("Details", execution);
        }

        public ActionResult GetExecutionTimeline(ICollection<Execution> executions, ICollection<string> statuses, string order)
        {
            if (executions == null)
            {
                executions = db.Executions.Include(e => e.Machine).Include(e => e.Reason).Include(e => e.User).ToList();
            }

            List<Status> statusesList = statuses.ToList().ConvertAll(status =>
            {
                Status s;
                return Enum.TryParse(status.Replace(" ", string.Empty), true, out s) ? s : Status.Running;
            });

            executions = executions
                .Where(execution => statusesList.Contains(execution.Status))
                .OrderBy(execution =>
                {
                    switch (order.Replace(" ", string.Empty))
                    {
                        case "endtime":
                            return execution.EndTime;
                        case "scheduletime":
                            return execution.ScheduleTime;
                        case "srarttime":
                        case "starttime":
                            return execution.SrartTime;
                        case "creationdate":
                        default:
                            return execution.CreationDate;
                    }
                })
                .ToList();

            return PartialView("Timeline", executions);
        }


        // POST: Executions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreationDate,Status,SrartTime,EndTime,ScheduleTime,UserId,ReasonId,MachineVLan,MachineIP")] Execution execution)
        {
            if (ModelState.IsValid)
            {
                db.Executions.Add(execution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MachineIP = new SelectList(db.Machines, "IP", "IP", execution.MachineIP);
            ViewBag.ReasonId = new SelectList(db.Reasons, "Id", "ReasonName", execution.ReasonId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", execution.UserId);
            return View(execution);
        }

        // GET: Executions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Execution execution = db.Executions.Find(id);
            if (execution == null)
            {
                return HttpNotFound();
            }
            ViewBag.MachineIP = new SelectList(db.Machines, "IP", "IP", execution.MachineIP);
            ViewBag.ReasonId = new SelectList(db.Reasons, "Id", "ReasonName", execution.ReasonId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", execution.UserId);
            return View(execution);
        }

        // POST: Executions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreationDate,Status,SrartTime,EndTime,ScheduleTime,UserId,ReasonId,MachineVLan,MachineIP")] Execution execution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(execution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MachineIP = new SelectList(db.Machines, "IP", "IP", execution.MachineIP);
            ViewBag.ReasonId = new SelectList(db.Reasons, "Id", "ReasonName", execution.ReasonId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", execution.UserId);
            return View(execution);
        }

        // GET: Executions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Execution execution = db.Executions.Find(id);
            if (execution == null)
            {
                return HttpNotFound();
            }
            return View(execution);
        }

        // POST: Executions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Execution execution = db.Executions.Find(id);
            db.Executions.Remove(execution);
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
