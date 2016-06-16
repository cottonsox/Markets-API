namespace MarketsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Horses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jockeys",
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
                "dbo.RaceHorses",
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
                .ForeignKey("dbo.Horses", t => t.HorseId, cascadeDelete: true)
                .ForeignKey("dbo.Jockeys", t => t.JockeyId, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.RaceId)
                .Index(t => t.JockeyId)
                .Index(t => t.HorseId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RaceMeetId = c.Guid(nullable: false),
                        Distance = c.Int(nullable: false),
                        RaceNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceMeets", t => t.RaceMeetId, cascadeDelete: true)
                .Index(t => t.RaceMeetId);
            
            CreateTable(
                "dbo.RaceMeets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TrackId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        RaceCount = c.Int(nullable: false),
                        TrackCondition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId);
            
            CreateTable(
                "dbo.Tracks",
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
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        Surname = c.String(),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RaceResultS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RaceHorseId = c.Guid(nullable: false),
                        Position = c.Int(nullable: false),
                        Margin = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceHorses", t => t.RaceHorseId, cascadeDelete: true)
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
                .ForeignKey("dbo.RaceResultS", t => t.RaceResultId, cascadeDelete: true)
                .Index(t => t.RaceResultId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RaceSectionals", "RaceResultId", "dbo.RaceResultS");
            DropForeignKey("dbo.RaceResultS", "RaceHorseId", "dbo.RaceHorses");
            DropForeignKey("dbo.RaceHorses", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.RaceHorses", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Races", "RaceMeetId", "dbo.RaceMeets");
            DropForeignKey("dbo.RaceMeets", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.RaceHorses", "JockeyId", "dbo.Jockeys");
            DropForeignKey("dbo.RaceHorses", "HorseId", "dbo.Horses");
            DropIndex("dbo.RaceSectionals", new[] { "RaceResultId" });
            DropIndex("dbo.RaceResultS", new[] { "RaceHorseId" });
            DropIndex("dbo.RaceMeets", new[] { "TrackId" });
            DropIndex("dbo.Races", new[] { "RaceMeetId" });
            DropIndex("dbo.RaceHorses", new[] { "TrainerId" });
            DropIndex("dbo.RaceHorses", new[] { "HorseId" });
            DropIndex("dbo.RaceHorses", new[] { "JockeyId" });
            DropIndex("dbo.RaceHorses", new[] { "RaceId" });
            DropTable("dbo.RaceSectionals");
            DropTable("dbo.RaceResultS");
            DropTable("dbo.Trainers");
            DropTable("dbo.Tracks");
            DropTable("dbo.RaceMeets");
            DropTable("dbo.Races");
            DropTable("dbo.RaceHorses");
            DropTable("dbo.Jockeys");
            DropTable("dbo.Horses");
        }
    }
}
