namespace NuelClinics.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _EmployeeDateOfBirth1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Phone", c => c.Int(nullable: false));
        }
    }
}
