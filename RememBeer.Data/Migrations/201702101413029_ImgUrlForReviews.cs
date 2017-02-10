namespace RememBeer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImgUrlForReviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BeerReviews", "ImgUrl", c => c.String(defaultValue: "~/Content/Images/default-beer.png"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BeerReviews", "ImgUrl");
        }
    }
}
