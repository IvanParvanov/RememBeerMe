namespace RememBeer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFixes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BeerReviews", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BeerReviews", "ModifiedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BeerReviews", "ModifiedAt", c => c.DateTime());
            AlterColumn("dbo.BeerReviews", "CreatedAt", c => c.DateTime());
        }
    }
}
