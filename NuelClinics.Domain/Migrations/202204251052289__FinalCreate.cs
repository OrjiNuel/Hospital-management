namespace NuelClinics.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _FinalCreate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Patients", new[] { "DepartmentID" });
            DropIndex("dbo.Patients", new[] { "WardID" });
            CreateIndex("dbo.Patients", "DepartmentId");
            CreateIndex("dbo.Patients", "WardId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Patients", new[] { "WardId" });
            DropIndex("dbo.Patients", new[] { "DepartmentId" });
            CreateIndex("dbo.Patients", "WardID");
            CreateIndex("dbo.Patients", "DepartmentID");
        }
    }
}
