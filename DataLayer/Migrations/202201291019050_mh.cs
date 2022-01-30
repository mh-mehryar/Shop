namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Cat_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Cat_Id" });
            DropColumn("dbo.Products", "Cat_Id");
            RenameColumn(table: "dbo.Products", name: "Category_Cat_Id", newName: "Cat_Id");
            AlterColumn("dbo.Products", "Cat_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Cat_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Cat_Id");
            AddForeignKey("dbo.Products", "Cat_Id", "dbo.Categories", "Cat_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cat_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Cat_Id" });
            AlterColumn("dbo.Products", "Cat_Id", c => c.Int());
            AlterColumn("dbo.Products", "Cat_Id", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Products", name: "Cat_Id", newName: "Category_Cat_Id");
            AddColumn("dbo.Products", "Cat_Id", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "Category_Cat_Id");
            AddForeignKey("dbo.Products", "Category_Cat_Id", "dbo.Categories", "Cat_Id");
        }
    }
}
