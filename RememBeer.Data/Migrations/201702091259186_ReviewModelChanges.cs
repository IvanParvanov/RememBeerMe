namespace RememBeer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BeerReviews", "Place", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BeerReviews", "Place", c => c.String(nullable: false, maxLength: 512));
        }
    }
}
