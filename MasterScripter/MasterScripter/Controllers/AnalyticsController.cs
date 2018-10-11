using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterScripter.DAL.Models;
using MasterScripter.Models;

namespace MasterScripter.Controllers
{
    public class AnalyticsController : Controller
    {
        private MasterScripterContext db = new MasterScripterContext();

        // GET: Analytics
        public ActionResult Index()
        {
            Dictionary<Status, int> totalStatuses = db.Executions.ToList().GroupBy(execution => execution.Status)
                .ToList().ToDictionary(input => input.Key, grouping => grouping.Count());

            Dictionary<Reason, int> totalReasons = db.Executions.ToList().GroupBy(execution => execution.Reason)
                .ToList().ToDictionary(input => input.Key, grouping => grouping.Count());

            Dictionary<Country, int> totalCountries = db.Machines.ToList().GroupBy(execution => execution.Country)
                .ToList().ToDictionary(input => input.Key, grouping => grouping.Count());

            Dictionary<Machine, int> totalMachine = db.Executions.ToList().GroupBy(execution => execution.Machine)
                .ToList().ToDictionary(input => input.Key, grouping => grouping.Count());


            var myData = from log in db.Executions
                group log by EntityFunctions.TruncateTime(log.CreationDate) into g
                orderby g.Key
                select new { CreateTime = g.Key, Count = g.Count() };


            Tuple<int, int, int> states = new Tuple<int, int, int>(db.Machines.Count(),
                db.Machines.Count(m => !m.IsDeleted),
                db.Machines.Count(m => m.IsDeleted));
          

            Dictionary<DateTime, int> totalExecutionsPerDay = myData.ToList().Where(i=>i.CreateTime!=null).ToDictionary(i=>(DateTime)i.CreateTime, i=>i.Count);

            AnalyticsViewModel analyticsViewModel = new AnalyticsViewModel()
            {
                TotalStatuses =  totalStatuses,
                TotalCountries = totalCountries,
                TotalReasons = totalReasons,
                TotalExecutionsPerDay = totalExecutionsPerDay,
                TotalMachines = totalMachine,
                MachinesState = states
            };

            return PartialView(analyticsViewModel);
        }

        public ActionResult GetLogger()
        {
            return PartialView("Logger");
        }
    }
}