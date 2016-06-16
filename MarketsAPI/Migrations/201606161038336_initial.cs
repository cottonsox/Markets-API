namespace MarketsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Horse",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jockey",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        LowWeight = c.Int(nullable: false),
                        Isapprentice = c.Boolean(nullable: false),
                        ApprenticeClaim = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RaceHorse",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        HorseId = c.Guid(nullable: false),
                        RaceId = c.Guid(nullable: false),
                        JockeyId = c.Guid(nullable: false),
                        TrainerId = c.Guid(nullable: false),
                        Barrier = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Horse", t => t.HorseId, cascadeDelete: true)
                .ForeignKey("dbo.Jockey", t => t.JockeyId, cascadeDelete: true)
                .ForeignKey("dbo.Race", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Trainer", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.HorseId)
                .Index(t => t.RaceId)
                .Index(t => t.JockeyId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RaceMeetId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Distance = c.Int(nullable: false),
                        RaceNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceMeet", t => t.RaceMeetId, cascadeDelete: true)
                .Index(t => t.RaceMeetId);
            
            CreateTable(
                "dbo.RaceMeet",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TrackId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Desription = c.String(),
                        RaceCount = c.Int(nullable: false),
                        TrackCondition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.String(),
                        State = c.Int(nullable: false),
                        Surface = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        Surname = c.String(),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RaceResult",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RaceHorseId = c.Guid(nullable: false),
                        Position = c.Int(nullable: false),
                        Margin = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceHorse", t => t.RaceHorseId, cascadeDelete: true)
                .Index(t => t.RaceHorseId);
            
            CreateTable(
                "dbo.RaceSectionals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RaceResultId = c.Guid(nullable: false),
                        SectionTime = c.Single(nullable: false),
                        SectionStart = c.Int(nullable: false),
                        Sectionend = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceResult", t => t.RaceResultId, cascadeDelete: true)
                .Index(t => t.RaceResultId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Level = c.Byte(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RaceSectionals", "RaceResultId", "dbo.RaceResult");
            DropForeignKey("dbo.RaceResult", "RaceHorseId", "dbo.RaceHorse");
            DropForeignKey("dbo.RaceHorse", "TrainerId", "dbo.Trainer");
            DropForeignKey("dbo.RaceHorse", "RaceId", "dbo.Race");
            DropForeignKey("dbo.Race", "RaceMeetId", "dbo.RaceMeet");
            DropForeignKey("dbo.RaceMeet", "TrackId", "dbo.Track");
            DropForeignKey("dbo.RaceHorse", "JockeyId", "dbo.Jockey");
            DropForeignKey("dbo.RaceHorse", "HorseId", "dbo.Horse");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RaceSectionals", new[] { "RaceResultId" });
            DropIndex("dbo.RaceResult", new[] { "RaceHorseId" });
            DropIndex("dbo.RaceMeet", new[] { "TrackId" });
            DropIndex("dbo.Race", new[] { "RaceMeetId" });
            DropIndex("dbo.RaceHorse", new[] { "TrainerId" });
            DropIndex("dbo.RaceHorse", new[] { "JockeyId" });
            DropIndex("dbo.RaceHorse", new[] { "RaceId" });
            DropIndex("dbo.RaceHorse", new[] { "HorseId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RaceSectionals");
            DropTable("dbo.RaceResult");
            DropTable("dbo.Trainer");
            DropTable("dbo.Track");
            DropTable("dbo.RaceMeet");
            DropTable("dbo.Race");
            DropTable("dbo.RaceHorse");
            DropTable("dbo.Jockey");
            DropTable("dbo.Horse");
        }
    }
}
