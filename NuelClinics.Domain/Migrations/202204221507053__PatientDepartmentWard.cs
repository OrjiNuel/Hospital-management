namespace NuelClinics.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _PatientDepartmentWard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "TypeId_ID", "dbo.EmployeeTypes");
            DropForeignKey("dbo.Patients", "DepartmentID_ID", "dbo.Departments");
            DropForeignKey("dbo.Patients", "WardID_ID", "dbo.Wards");
            DropIndex("dbo.Employees", new[] { "TypeId_ID" });
            DropIndex("dbo.Patients", new[] { "DepartmentID_ID" });
            DropIndex("dbo.Patients", new[] { "WardID_ID" });
            RenameColumn(table: "dbo.Employees", name: "TypeId_ID", newName: "EmployeeTypeId");
            RenameColumn(table: "dbo.Patients", name: "DepartmentID_ID", newName: "DepartmentID");
            RenameColumn(table: "dbo.Patients", name: "WardID_ID", newName: "WardID");
            AlterColumn("dbo.Employees", "EmployeeTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "WardID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "EmployeeTypeId");
            CreateIndex("dbo.Patients", "DepartmentID");
            CreateIndex("dbo.Patients", "WardID");
            AddForeignKey("dbo.Employees", "EmployeeTypeId", "dbo.EmployeeTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "DepartmentID", "dbo.Departments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "WardID", "dbo.Wards", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "WardID", "dbo.Wards");
            DropForeignKey("dbo.Patients", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Employees", "EmployeeTypeId", "dbo.EmployeeTypes");
            DropIndex("dbo.Patients", new[] { "WardID" });
            DropIndex("dbo.Patients", new[] { "DepartmentID" });
            DropIndex("dbo.Employees", new[] { "EmployeeTypeId" });
            AlterColumn("dbo.Patients", "WardID", c => c.Int());
            AlterColumn("dbo.Patients", "DepartmentID", c => c.Int());
            AlterColumn("dbo.Employees", "EmployeeTypeId", c => c.Int());
            RenameColumn(table: "dbo.Patients", name: "WardID", newName: "WardID_ID");
            RenameColumn(table: "dbo.Patients", name: "DepartmentID", newName: "DepartmentID_ID");
            RenameColumn(table: "dbo.Employees", name: "EmployeeTypeId", newName: "TypeId_ID");
            CreateIndex("dbo.Patients", "WardID_ID");
            CreateIndex("dbo.Patients", "DepartmentID_ID");
            CreateIndex("dbo.Employees", "TypeId_ID");
            AddForeignKey("dbo.Patients", "WardID_ID", "dbo.Wards", "ID");
            AddForeignKey("dbo.Patients", "DepartmentID_ID", "dbo.Departments", "ID");
            AddForeignKey("dbo.Employees", "TypeId_ID", "dbo.EmployeeTypes", "ID");
        }
    }
}
