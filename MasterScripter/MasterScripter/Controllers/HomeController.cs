using MasterScripter.BL.Utils;
using MasterScripter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterScripter.Controllers
{
    [Authorize]
    [ConnectedUserFilterAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MasterScripterContext db = new MasterScripterContext();
            MasterScripter.DAL.Models.User user = db.Users.FirstOrDefault(u => u.Email.Equals(User.Identity.Name));
            if (user != null)
            {
                return View();
            }
            return View("NotConnectedYet");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult NotConnectedYet()
        {
            //ViewBag.Message = "Your application description page.";

            return View("NotConnectedYet");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}