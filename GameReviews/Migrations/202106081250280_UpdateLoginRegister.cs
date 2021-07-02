namespace GameReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLoginRegister : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Text = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.GameId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        PictureURL = c.String(),
                        SteamURL = c.String(),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Upvotes",
                c => new
                    {
                        UpvoteId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UpvoteId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.GameId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Upvotes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Upvotes", "GameId", "dbo.Games");
            DropForeignKey("dbo.Comments", "GameId", "dbo.Games");
            DropIndex("dbo.Upvotes", new[] { "User_Id" });
            DropIndex("dbo.Upvotes", new[] { "GameId" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "GameId" });
            DropTable("dbo.Upvotes");
            DropTable("dbo.Games");
            DropTable("dbo.Comments");
        }
    }
}
