namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Cat_Id = c.Int(nullable: false, identity: true),
                        Cat_Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Cat_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Pro_Id = c.Int(nullable: false, identity: true),
                        Cat_Id = c.String(nullable: false),
                        Pro_Title = c.String(nullable: false, maxLength: 150),
                        Pro_Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 350),
                        Is_Active = c.Boolean(nullable: false),
                        Image = c.String(),
                        Category_Cat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Pro_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Cat_Id)
                .Index(t => t.Category_Cat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Cat_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Cat_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
