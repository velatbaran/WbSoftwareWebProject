namespace WbSoftwareWebProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortText = c.String(nullable: false),
                        LongText = c.String(nullable: false),
                        ProfileImage = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedUsername = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Website = c.String(),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Comment = c.String(nullable: false),
                        CommentStatus = c.Boolean(nullable: false),
                        ProfileImage = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedUsername = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Twitter = c.String(),
                        Instagram = c.String(),
                        Telegram = c.String(),
                        Github = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedUsername = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer = c.String(nullable: false, maxLength: 200),
                        ProjectName = c.String(nullable: false, maxLength: 200),
                        ServicesId = c.Int(nullable: false),
                        ProjectDate = c.DateTime(nullable: false),
                        UsedTeknologies = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image1 = c.String(nullable: false, maxLength: 100),
                        Image2 = c.String(nullable: false, maxLength: 50),
                        Image3 = c.String(nullable: false, maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedUsername = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServicesId, cascadeDelete: true)
                .Index(t => t.ServicesId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedUsername = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resume",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Corporation = c.String(nullable: false, maxLength: 100),
                        Task = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Text = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedUsername = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ServicesId", "dbo.Services");
            DropIndex("dbo.Projects", new[] { "ServicesId" });
            DropTable("dbo.Resume");
            DropTable("dbo.Services");
            DropTable("dbo.Projects");
            DropTable("dbo.Contact");
            DropTable("dbo.Comments");
            DropTable("dbo.About");
        }
    }
}
