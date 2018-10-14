using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterScripter.BL.Utils;
using MasterScripter.DAL.Models;
using MasterScripter.Models;
using Microsoft.Ajax.Utilities;

namespace MasterScripter.Controllers
{
    [Authorize]
    [ConnectedUserFilterAttribute]

    public class QueueManagerController : Controller
    {
        // GET: QueueManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: QueueManager
        public ActionResult StartQueue()
        {
            QueueManager.Instance.Start();

            return Json(new { status = Status.Running}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StopQueue()
        {
            QueueManager.Instance.Stop();

            return Json(new { status = Status.Waiting }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStatus()
        {
            Status status = QueueManager.Instance.GetStatus();
            IEnumerable<LogMessage> log = QueueManager.Instance.GetLogMessages();
            int availableThreads = QueueManager.Instance.GetAvailableThreads();
            int currentRunningTasks = QueueManager.Instance.GetCurrentRunningTasks();

            return Json(new { status = status, log = log , availableThreads  = availableThreads, currentRunningTasks = currentRunningTasks }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult AddToTheQueue()
        {
             QueueManager.Instance.AddTask(new Execution());

            return Json(new { status = Status.Succeeded }, JsonRequestBehavior.AllowGet);
        }
    }
}