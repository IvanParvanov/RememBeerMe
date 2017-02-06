namespace RememBeer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BeerReviews", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BeerReviews", new[] { "User_Id" });
            DropColumn("dbo.BeerReviews", "UserId");
            RenameColumn(table: "dbo.BeerReviews", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.BeerReviews", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.BeerReviews", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BeerReviews", "UserId");
            AddForeignKey("dbo.BeerReviews", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BeerReviews", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.BeerReviews", new[] { "UserId" });
            AlterColumn("dbo.BeerReviews", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.BeerReviews", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.BeerReviews", name: "UserId", newName: "User_Id");
            AddColumn("dbo.BeerReviews", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.BeerReviews", "User_Id");
            AddForeignKey("dbo.BeerReviews", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
