using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MasterScripter.DAL.Models;

namespace MasterScripter.Models
{
    public class MasterScripterContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MasterScripterContext() : base("name=MasterScripterContext")
        {
        }

        public DbSet<Script> Scripts { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Execution> Executions { get; set; }
        public DbSet<ExecutionsScripts> ExecutionsScriptses { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
