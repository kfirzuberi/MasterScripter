using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterScripter.Models;

namespace MasterScripter.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        public ActionResult Index()
        {
            var managementViewModel = new ManagementViewModel()
            {
                Companies = DAL.Utils.FakeData.GetCompanies(),
                Reasons = DAL.Utils.FakeData.GetReasons()
            };

            return View(managementViewModel);
        }
    }
}