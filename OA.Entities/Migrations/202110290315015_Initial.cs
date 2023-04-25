namespace OA.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiBenh",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 250),
                        NgayNhap = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        GiaBan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipienceDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipienceId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.Recipience", t => t.RecipienceId, cascadeDelete: true)
                .Index(t => t.RecipienceId)
                .Index(t => t.MedicineId);
            
            CreateTable(
                "dbo.Recipience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DayOfFound = c.DateTime(nullable: false),
                        Description = c.String(),
                        PatientId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 250),
                        Address = c.String(),
                        DateOfBirth = c.String(),
                        Gender = c.Int(nullable: false),
                        Room = c.String(nullable: false, maxLength: 150),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhieuKham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 150),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        TrieuChung = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NgayTaiKham = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 250),
                        Address = c.String(),
                        Gender = c.Int(nullable: false),
                        Phone = c.String(),
                        Position = c.Int(nullable: false),
                        DateOfBirth = c.String(),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipienceDetail", "RecipienceId", "dbo.Recipience");
            DropForeignKey("dbo.Recipience", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PhieuKham", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PhieuKham", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.RecipienceDetail", "MedicineId", "dbo.Medicines");
            DropIndex("dbo.PhieuKham", new[] { "DoctorId" });
            DropIndex("dbo.PhieuKham", new[] { "PatientId" });
            DropIndex("dbo.Recipience", new[] { "PatientId" });
            DropIndex("dbo.RecipienceDetail", new[] { "MedicineId" });
            DropIndex("dbo.RecipienceDetail", new[] { "RecipienceId" });
            DropTable("dbo.Users");
            DropTable("dbo.PhieuKham");
            DropTable("dbo.Patients");
            DropTable("dbo.Recipience");
            DropTable("dbo.RecipienceDetail");
            DropTable("dbo.Medicines");
            DropTable("dbo.LoaiBenh");
        }
    }
}
