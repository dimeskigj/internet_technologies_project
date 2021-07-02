namespace GameReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPictureURLToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserPhotoURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "UserPhotoURL");
        }
    }
}
