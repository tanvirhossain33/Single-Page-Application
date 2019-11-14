namespace Importer.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Syllabus = c.String(),
                        DevelopmentOfficer = c.String(),
                        Manager = c.String(),
                        ActiveDate = c.DateTime(nullable: false),
                        SyllabusFileName = c.String(),
                        TradeId = c.String(),
                        LevelId = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletionTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        TradeId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletionTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trades", t => t.TradeId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.TradeId);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletionTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Levels", "TradeId", "dbo.Trades");
            DropIndex("dbo.Trades", new[] { "Id" });
            DropIndex("dbo.Levels", new[] { "TradeId" });
            DropIndex("dbo.Levels", new[] { "Id" });
            DropIndex("dbo.Documents", new[] { "Id" });
            DropTable("dbo.Trades");
            DropTable("dbo.Levels");
            DropTable("dbo.Documents");
        }
    }
}
