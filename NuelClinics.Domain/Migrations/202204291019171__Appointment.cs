namespace NuelClinics.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Appointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Date = c.DateTime(nullable: false),
                        CardNum = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "ServiceId", "dbo.Services");
            DropIndex("dbo.Appointments", new[] { "ServiceId" });
            DropTable("dbo.Appointments");
        }
    }
}
