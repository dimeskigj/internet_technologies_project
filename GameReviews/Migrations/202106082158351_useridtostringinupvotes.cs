namespace GameReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridtostringinupvotes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Upvotes", new[] { "User_Id" });
            DropColumn("dbo.Upvotes", "UserId");
            RenameColumn(table: "dbo.Upvotes", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Upvotes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Upvotes", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Upvotes", new[] { "UserId" });
            AlterColumn("dbo.Upvotes", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Upvotes", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Upvotes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Upvotes", "User_Id");
        }
    }
}
