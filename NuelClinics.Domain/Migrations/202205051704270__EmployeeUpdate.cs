namespace NuelClinics.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _EmployeeUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EmployeeTypeId", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeTypeId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Employees", "EmployeeTypeId");
            AddForeignKey("dbo.Employees", "EmployeeTypeId", "dbo.EmployeeTypes", "ID", cascadeDelete: true);
        }
    }
}
