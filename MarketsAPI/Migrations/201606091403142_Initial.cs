namespace MarketsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Horse",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jockey",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        Surname = c.String(),
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
                        RaceId = c.Guid(nullable: false),
                        JockeyId = c.Guid(nullable: false),
                        HorseId = c.Guid(nullable: false),
                        TrainerId = c.Guid(nullable: false),
                        Barrier = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Horse", t => t.HorseId, cascadeDelete: true)
                .ForeignKey("dbo.Jockey", t => t.JockeyId, cascadeDelete: true)
                .ForeignKey("dbo.Race", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Trainer", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.RaceId)
                .Index(t => t.JockeyId)
                .Index(t => t.HorseId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RaceMeetId = c.Guid(nullable: false),
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
                        Name = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RaceSectionals", "RaceResultId", "dbo.RaceResult");
            DropForeignKey("dbo.RaceResult", "RaceHorseId", "dbo.RaceHorse");
            DropForeignKey("dbo.RaceHorse", "TrainerId", "dbo.Trainer");
            DropForeignKey("dbo.RaceHorse", "RaceId", "dbo.Race");
            DropForeignKey("dbo.Race", "RaceMeetId", "dbo.RaceMeet");
            DropForeignKey("dbo.RaceMeet", "TrackId", "dbo.Track");
            DropForeignKey("dbo.RaceHorse", "JockeyId", "dbo.Jockey");
            DropForeignKey("dbo.RaceHorse", "HorseId", "dbo.Horse");
            DropIndex("dbo.RaceSectionals", new[] { "RaceResultId" });
            DropIndex("dbo.RaceResult", new[] { "RaceHorseId" });
            DropIndex("dbo.RaceMeet", new[] { "TrackId" });
            DropIndex("dbo.Race", new[] { "RaceMeetId" });
            DropIndex("dbo.RaceHorse", new[] { "TrainerId" });
            DropIndex("dbo.RaceHorse", new[] { "HorseId" });
            DropIndex("dbo.RaceHorse", new[] { "JockeyId" });
            DropIndex("dbo.RaceHorse", new[] { "RaceId" });
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
