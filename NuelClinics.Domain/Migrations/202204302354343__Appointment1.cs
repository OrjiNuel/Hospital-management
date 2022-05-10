namespace NuelClinics.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Appointment1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Email", c => c.String());
            AlterColumn("dbo.Appointments", "Phone", c => c.String());
            AlterColumn("dbo.Appointments", "Name", c => c.String());
        }
    }
}
