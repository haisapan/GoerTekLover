namespace GoerTekLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        IpAddress = c.String(maxLength: 100),
                        LoginTime = c.DateTime(nullable: false),
                        LogoutTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbDictionary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dict_Name = c.String(),
                        Dict_Value = c.String(),
                        Dict_Code = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuModel",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        MenuDisplayName = c.String(),
                        MenuLink = c.String(),
                        ParentMenuId = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        ImageDescription = c.String(),
                        ImageText = c.String(),
                        ImageSize = c.Double(nullable: false),
                        Md5 = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.UserProfile", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            AddColumn("dbo.UserProfile", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserDetail", "IsVip", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserDetail", "Country", c => c.String());
            AddColumn("dbo.UserDetail", "Province", c => c.String());
            AddColumn("dbo.UserDetail", "City", c => c.String());
            AddColumn("dbo.UserDetail", "ZipCode", c => c.String());
            AddColumn("dbo.UserDetail", "WeiXinId", c => c.String());
            AddColumn("dbo.UserDetail", "WeiXinName", c => c.String());
        }
        
        public override void Down()
        {
            DropIndex("dbo.Images", new[] { "User_UserId" });
            DropForeignKey("dbo.Images", "User_UserId", "dbo.UserProfile");
            DropColumn("dbo.UserDetail", "WeiXinName");
            DropColumn("dbo.UserDetail", "WeiXinId");
            DropColumn("dbo.UserDetail", "ZipCode");
            DropColumn("dbo.UserDetail", "City");
            DropColumn("dbo.UserDetail", "Province");
            DropColumn("dbo.UserDetail", "Country");
            DropColumn("dbo.UserDetail", "IsVip");
            DropColumn("dbo.UserProfile", "IsDeleted");
            DropTable("dbo.Images");
            DropTable("dbo.MenuModel");
            DropTable("dbo.DbDictionary");
            DropTable("dbo.LoginLogs");
        }
    }
}
