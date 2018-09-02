using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterScripter.DAL.Models;

namespace MasterScripter.Models
{
    public class ManagementViewModel
    {
        public ICollection<Company> Companies { get; set; }
        public ICollection<Reason> Reasons { get; set; }
    }
}