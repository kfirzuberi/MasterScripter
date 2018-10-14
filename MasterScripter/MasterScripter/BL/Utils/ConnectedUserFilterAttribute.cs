using MasterScripter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterScripter.BL.Utils
{
    public class ConnectedUserFilterAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MasterScripterContext db = new MasterScripterContext();

            MasterScripter.DAL.Models.User user = db.Users.FirstOrDefault(u => u.Email.Equals(filterContext.HttpContext.User.Identity.Name));
            if (user == null && !filterContext.HttpContext.Request.RawUrl.Contains("NotConnectedYet"))
            {
                filterContext.Result = new RedirectResult("~/Home/NotConnectedYet");

            }
            base.OnActionExecuting(filterContext);

        }
    }
}