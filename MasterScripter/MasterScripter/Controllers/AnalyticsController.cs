using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterScripter.BL.Utils;
using MasterScripter.DAL.Models;
using MasterScripter.Models;

namespace MasterScripter.Controllers
{
    [Authorize]
    [ConnectedUserFilterAttribute]
    public class AnalyticsController : Controller
    {
        private MasterScripterContext db = new MasterScripterContext();

        // GET: Analytics
        public ActionResult Index()
        {
            var user = db.Users.FirstOrDefault(u => u.Email.Equals(User.Identity.Name));

            List<Execution> executions = db.Executions.ToList();
            List<Machine> machines = db.Machines.ToList();

            if (user.Role != Role.Admin && user.Role != Role.Manager)
            {
                executions = executions.Where(e => e.Machine.CompanyCode == user.CompanyCode).ToList();
                machines = machines.Where(m=>m.CompanyCode == user.CompanyCode).ToList();
            }

            Dictionary<Status, int> totalStatuses = executions.GroupBy(execution => execution.Status)
                .ToList().ToDictionary(input => input.Key, grouping => grouping.Count());

            Dictionary<Reason, int> totalReasons = executions.GroupBy(execution => execution.Reason)
                .ToList().ToDictionary(input => input.Key, grouping => grouping.Count());

            Dictionary<Country, int> totalCountries = machines.GroupBy(execution => execution.Country)
                .ToList().ToDictionary(input => input.Key, grouping => grouping.Count());

            Dictionary<Machine, int> totalMachine = executions.GroupBy(execution => execution.Machine)
                .ToList().ToDictionary(input => input.Key, grouping => grouping.Count());


            var myData = from log in executions
                         group log by log.CreationDate.Value.Date into g
                orderby g.Key
                select new { CreateTime = g.Key, Count = g.Count() };


            Tuple<int, int, int> states = new Tuple<int, int, int>(machines.Count(),
                machines.Count(m => !m.IsDeleted),
                machines.Count(m => m.IsDeleted));
          

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

        public ActionResult GetKmeansData()
        {
            List<Tuple<int, int[]>> ff = new List<Tuple<int, int[]>>();

            int sctiptCount = db.Scripts.Max(s => s.Id) + 1;

            var features = db.Executions.ToList().ConvertAll<Tuple<int, int[]>>(input =>
            {
                var arr = new int[sctiptCount];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = input.ExecutionsScriptses.Any(s => s.ScriptId == i) ? 1 : 0;

                return new Tuple<int, int[]>(input.Id, arr);
            }).ToList();

            return Json(new {data = features }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLogger()
        {
            return PartialView("Logger");
        }
    }
}