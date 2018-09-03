using System.Collections.Generic;
using MasterScripter.DAL.Models;
using MasterScripter.DAL.Utils;

namespace MasterScripter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MasterScripter.Models.MasterScripterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private static void Run(DbContext db)
        {
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        protected override void Seed(MasterScripter.Models.MasterScripterContext context)
        {

            List<User> users = FakeData.GetUsers();

            context.Countries.AddRange(FakeData.GetCountries());
            context.Companies.AddRange(FakeData.GetCompanies());
            context.Users.AddRange(users);
            context.FileTypes.AddRange(FakeData.GetFileTypes());

            Run(context);

            var adminOrManagers = from st in context.Users
                where st.Role == Role.Admin || st.Role == Role.Manager
                select st.Id;

            var viewers = from st in context.Users
                where st.Role == Role.Viewer
                select st.Id;

            var filesType = from ft in context.FileTypes
                select ft;

            context.Scripts.AddRange(FakeData.GetScripts(adminOrManagers.ToList(), filesType.ToList()));
            context.Machines.AddRange(FakeData.GetMachines());
            context.Reasons.AddRange(FakeData.GetReasons());
            
            Run(context);

            var reasons = from st in context.Reasons
                select st.Id;

            var machines = from st in context.Machines
                select st;

            context.Executions.AddRange(FakeData.GetExecutions(50, adminOrManagers.ToList(), reasons.ToList(),
                machines.ToList()));

            Run(context);

            var executions = from st in context.Executions
                select st;

            var scripts = from st in context.Scripts
                select st;

            context.ExecutionsScriptses.AddRange(FakeData.GetExecutionsScriptses(executions.ToList(), scripts.ToList()));

            Run(context);
        }
    }
}
