namespace MasterScripter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                        ExecutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Executions", t => t.ExecutionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ExecutionId);
            
            CreateTable(
                "dbo.Executions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Status = c.Int(nullable: false),
                        SrartTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        ScheduleTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                        ReasonId = c.Int(nullable: false),
                        MachineVLan = c.Int(nullable: false),
                        MachineIP = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Machines", t => new { t.MachineIP, t.MachineVLan })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.Reasons", t => t.ReasonId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ReasonId)
                .Index(t => new { t.MachineIP, t.MachineVLan });
            
            CreateTable(
                "dbo.ExecutionsScripts",
                c => new
                    {
                        ScriptId = c.Int(nullable: false),
                        ScriptVersion = c.Int(nullable: false),
                        ExecutionId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        SrartTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScriptId, t.ScriptVersion, t.ExecutionId })
                .ForeignKey("dbo.Executions", t => t.ExecutionId, cascadeDelete: true)
                .ForeignKey("dbo.Scripts", t => new { t.ScriptId, t.ScriptVersion }, cascadeDelete: true)
                .Index(t => new { t.ScriptId, t.ScriptVersion })
                .Index(t => t.ExecutionId);
            
            CreateTable(
                "dbo.Scripts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Content = c.String(),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Cost = c.Double(nullable: false),
                        FileTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Version })
                .ForeignKey("dbo.FileTypes", t => t.FileTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FileTypeId);
            
            CreateTable(
                "dbo.FileTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Language = c.String(maxLength: 20),
                        FileExt = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Role = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CompanyCode = c.Int(nullable: false),
                        CreationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyCode, cascadeDelete: true)
                .Index(t => t.CompanyCode);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        IP = c.String(nullable: false, maxLength: 20),
                        VLan = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CompanyCode = c.Int(nullable: false),
                        CreationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IP, t.VLan })
                .ForeignKey("dbo.Companies", t => t.CompanyCode, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CompanyCode)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Lon = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReasonName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Executions", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.ExecutionsScripts", new[] { "ScriptId", "ScriptVersion" }, "dbo.Scripts");
            DropForeignKey("dbo.Scripts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Executions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CompanyCode", "dbo.Companies");
            DropForeignKey("dbo.Executions", new[] { "MachineIP", "MachineVLan" }, "dbo.Machines");
            DropForeignKey("dbo.Machines", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Machines", "CompanyCode", "dbo.Companies");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Scripts", "FileTypeId", "dbo.FileTypes");
            DropForeignKey("dbo.ExecutionsScripts", "ExecutionId", "dbo.Executions");
            DropForeignKey("dbo.Comments", "ExecutionId", "dbo.Executions");
            DropIndex("dbo.Machines", new[] { "CountryId" });
            DropIndex("dbo.Machines", new[] { "CompanyCode" });
            DropIndex("dbo.Users", new[] { "CompanyCode" });
            DropIndex("dbo.Scripts", new[] { "FileTypeId" });
            DropIndex("dbo.Scripts", new[] { "UserId" });
            DropIndex("dbo.ExecutionsScripts", new[] { "ExecutionId" });
            DropIndex("dbo.ExecutionsScripts", new[] { "ScriptId", "ScriptVersion" });
            DropIndex("dbo.Executions", new[] { "MachineIP", "MachineVLan" });
            DropIndex("dbo.Executions", new[] { "ReasonId" });
            DropIndex("dbo.Executions", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ExecutionId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.Reasons");
            DropTable("dbo.Countries");
            DropTable("dbo.Machines");
            DropTable("dbo.Companies");
            DropTable("dbo.Users");
            DropTable("dbo.FileTypes");
            DropTable("dbo.Scripts");
            DropTable("dbo.ExecutionsScripts");
            DropTable("dbo.Executions");
            DropTable("dbo.Comments");
        }
    }
}
