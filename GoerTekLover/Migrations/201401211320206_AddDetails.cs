namespace GoerTekLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        QQ = c.Int(nullable: false),
                        WeiBoId = c.String(),
                        WeiBoName = c.String(),
                        IsMarried = c.Boolean(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        UserProfile_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_UserId)
                .Index(t => t.UserProfile_UserId);
            
            AddColumn("dbo.UserProfile", "IsLocked", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserProfile", "Age");
            DropColumn("dbo.UserProfile", "Sex");
            DropColumn("dbo.UserProfile", "Birthday");
            DropColumn("dbo.UserProfile", "Address");
            DropColumn("dbo.UserProfile", "PhoneNumber");
            DropColumn("dbo.UserProfile", "QQ");
            DropColumn("dbo.UserProfile", "WeiBoId");
            DropColumn("dbo.UserProfile", "WeiBoName");
            DropColumn("dbo.UserProfile", "IsMarried");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "IsMarried", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserProfile", "WeiBoName", c => c.String());
            AddColumn("dbo.UserProfile", "WeiBoId", c => c.String());
            AddColumn("dbo.UserProfile", "QQ", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfile", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfile", "Address", c => c.String());
            AddColumn("dbo.UserProfile", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProfile", "Sex", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserProfile", "Age", c => c.Int(nullable: false));
            DropIndex("dbo.UserDetail", new[] { "UserProfile_UserId" });
            DropForeignKey("dbo.UserDetail", "UserProfile_UserId", "dbo.UserProfile");
            DropColumn("dbo.UserProfile", "IsLocked");
            DropTable("dbo.UserDetail");
        }
    }
}
