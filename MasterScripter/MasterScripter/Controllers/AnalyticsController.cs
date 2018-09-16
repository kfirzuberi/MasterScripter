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


            var myData = from log in db.Executions
                group log by EntityFunctions.TruncateTime(log.CreationDate) into g
                orderby g.Key
                select new { CreateTime = g.Key, Count = g.Count() };

            Dictionary<DateTime?, int> rr = myData.ToList().ToDictionary(i=>i.CreateTime, i=>i.Count);

            AnalyticsViewModel analyticsViewModel = new AnalyticsViewModel()
            {
                TotalStatuses =  totalStatuses,
                TotalCountries = totalCountries,
                TotalReasons = totalReasons
            };

            return PartialView(analyticsViewModel);
        }
    }
}