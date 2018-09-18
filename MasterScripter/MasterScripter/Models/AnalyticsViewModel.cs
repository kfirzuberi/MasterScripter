using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterScripter.DAL.Models;

namespace MasterScripter.Models
{

    public class AnalyticsViewModel
    {
        public Dictionary<Status, int> TotalStatuses { get; set; }
        public Dictionary<Reason, int> TotalReasons { get; set; }
        public Dictionary<Country, int> TotalCountries { get; set; }
        public Dictionary<Machine, int> TotalMachines { get; set; }
        public Tuple<int, int, int> MachinesState { get; set; }
        public Dictionary<DateTime, int> TotalExecutionsPerDay { get; set; }
    }
}