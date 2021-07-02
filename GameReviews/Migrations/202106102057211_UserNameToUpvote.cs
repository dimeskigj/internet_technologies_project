namespace GameReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameToUpvote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Upvotes", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Upvotes", "UserName");
        }
    }
}
