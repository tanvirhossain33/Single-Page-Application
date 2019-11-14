namespace Importer.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestEnitityMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestEnities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestEnities");
        }
    }
}
