namespace NuelClinics.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _EmployeeDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Date_Of_Birth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employees", "Date_Of_Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Date_Of_Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employees", "Date_Of_Birth");
        }
    }
}
