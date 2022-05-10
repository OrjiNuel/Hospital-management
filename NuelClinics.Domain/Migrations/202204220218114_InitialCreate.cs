namespace NuelClinics.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NuelClinicUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        NuelClinicUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NuelClinicUsers", t => t.NuelClinicUser_Id)
                .Index(t => t.NuelClinicUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        NuelClinicUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.NuelClinicUsers", t => t.NuelClinicUser_Id)
                .Index(t => t.NuelClinicUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        NuelClinicUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.NuelClinicUsers", t => t.NuelClinicUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.NuelClinicUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        Date_Of_Date = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Start_Date = c.DateTime(nullable: false),
                        TypeId_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeTypes", t => t.TypeId_ID)
                .Index(t => t.TypeId_ID);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        DepartmentID_ID = c.Int(),
                        WardID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID_ID)
                .ForeignKey("dbo.Wards", t => t.WardID_ID)
                .Index(t => t.DepartmentID_ID)
                .Index(t => t.WardID_ID);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pharmaceuticals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Exp_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Patients", "WardID_ID", "dbo.Wards");
            DropForeignKey("dbo.Patients", "DepartmentID_ID", "dbo.Departments");
            DropForeignKey("dbo.Employees", "TypeId_ID", "dbo.EmployeeTypes");
            DropForeignKey("dbo.IdentityUserRoles", "NuelClinicUser_Id", "dbo.NuelClinicUsers");
            DropForeignKey("dbo.IdentityUserLogins", "NuelClinicUser_Id", "dbo.NuelClinicUsers");
            DropForeignKey("dbo.IdentityUserClaims", "NuelClinicUser_Id", "dbo.NuelClinicUsers");
            DropIndex("dbo.Patients", new[] { "WardID_ID" });
            DropIndex("dbo.Patients", new[] { "DepartmentID_ID" });
            DropIndex("dbo.Employees", new[] { "TypeId_ID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "NuelClinicUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "NuelClinicUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "NuelClinicUser_Id" });
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Services");
            DropTable("dbo.Pharmaceuticals");
            DropTable("dbo.Wards");
            DropTable("dbo.Patients");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.NuelClinicUsers");
        }
    }
}
