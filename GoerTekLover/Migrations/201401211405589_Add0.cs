namespace GoerTekLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add0 : DbMigration
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
        }
        
        public override void Down()
        {
            
        }
    }
}
