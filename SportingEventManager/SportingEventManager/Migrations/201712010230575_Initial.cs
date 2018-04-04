namespace SportingEventManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeRanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Min = c.Int(nullable: false),
                        Max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 75),
                        State = c.String(nullable: false, maxLength: 75),
                        Street = c.String(maxLength: 75),
                        Zip = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 75),
                        State = c.String(nullable: false, maxLength: 75),
                        Street = c.String(nullable: false, maxLength: 75),
                        Zip = c.String(nullable: false, maxLength: 75),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SportsEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        AgeRangeId = c.Int(),
                        GenderId = c.Int(),
                        LocationId = c.Int(),
                        OrganizerId = c.Int(),
                        ScheduleId = c.Int(),
                        SportId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgeRanges", t => t.AgeRangeId)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId)
                .ForeignKey("dbo.Sports", t => t.SportId)
                .Index(t => t.AgeRangeId)
                .Index(t => t.GenderId)
                .Index(t => t.LocationId)
                .Index(t => t.OrganizerId)
                .Index(t => t.ScheduleId)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.Organizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 75),
                        State = c.String(nullable: false, maxLength: 75),
                        Street = c.String(maxLength: 75),
                        Zip = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        GenderId = c.Int(),
                        Birthdate = c.DateTime(nullable: false),
                        City = c.String(nullable: false, maxLength: 75),
                        State = c.String(nullable: false, maxLength: 75),
                        Street = c.String(maxLength: 75),
                        Zip = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Guardians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 75),
                        State = c.String(nullable: false, maxLength: 75),
                        Zip = c.String(nullable: false, maxLength: 20),
                        Street = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        DrivingLicense = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 50),
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
            
            CreateTable(
                "dbo.CoachAgeRanges",
                c => new
                    {
                        Coach_Id = c.Int(nullable: false),
                        AgeRange_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Coach_Id, t.AgeRange_Id })
                .ForeignKey("dbo.Coaches", t => t.Coach_Id, cascadeDelete: true)
                .ForeignKey("dbo.AgeRanges", t => t.AgeRange_Id, cascadeDelete: true)
                .Index(t => t.Coach_Id)
                .Index(t => t.AgeRange_Id);
            
            CreateTable(
                "dbo.GenderCoaches",
                c => new
                    {
                        Gender_Id = c.Int(nullable: false),
                        Coach_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gender_Id, t.Coach_Id })
                .ForeignKey("dbo.Genders", t => t.Gender_Id, cascadeDelete: true)
                .ForeignKey("dbo.Coaches", t => t.Coach_Id, cascadeDelete: true)
                .Index(t => t.Gender_Id)
                .Index(t => t.Coach_Id);
            
            CreateTable(
                "dbo.LocationCoaches",
                c => new
                    {
                        Location_Id = c.Int(nullable: false),
                        Coach_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_Id, t.Coach_Id })
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .ForeignKey("dbo.Coaches", t => t.Coach_Id, cascadeDelete: true)
                .Index(t => t.Location_Id)
                .Index(t => t.Coach_Id);
            
            CreateTable(
                "dbo.SportsEventCoaches",
                c => new
                    {
                        SportsEvent_Id = c.Int(nullable: false),
                        Coach_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SportsEvent_Id, t.Coach_Id })
                .ForeignKey("dbo.SportsEvents", t => t.SportsEvent_Id, cascadeDelete: true)
                .ForeignKey("dbo.Coaches", t => t.Coach_Id, cascadeDelete: true)
                .Index(t => t.SportsEvent_Id)
                .Index(t => t.Coach_Id);
            
            CreateTable(
                "dbo.GuardianPlayers",
                c => new
                    {
                        Guardian_Id = c.Int(nullable: false),
                        Player_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guardian_Id, t.Player_Id })
                .ForeignKey("dbo.Guardians", t => t.Guardian_Id, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .Index(t => t.Guardian_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.PlayerSportsEvents",
                c => new
                    {
                        Player_Id = c.Int(nullable: false),
                        SportsEvent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.SportsEvent_Id })
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .ForeignKey("dbo.SportsEvents", t => t.SportsEvent_Id, cascadeDelete: true)
                .Index(t => t.Player_Id)
                .Index(t => t.SportsEvent_Id);
            
            CreateTable(
                "dbo.ScheduleCoaches",
                c => new
                    {
                        Schedule_Id = c.Int(nullable: false),
                        Coach_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Schedule_Id, t.Coach_Id })
                .ForeignKey("dbo.Schedules", t => t.Schedule_Id, cascadeDelete: true)
                .ForeignKey("dbo.Coaches", t => t.Coach_Id, cascadeDelete: true)
                .Index(t => t.Schedule_Id)
                .Index(t => t.Coach_Id);
            
            CreateTable(
                "dbo.SportCoaches",
                c => new
                    {
                        Sport_Id = c.Int(nullable: false),
                        Coach_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sport_Id, t.Coach_Id })
                .ForeignKey("dbo.Sports", t => t.Sport_Id, cascadeDelete: true)
                .ForeignKey("dbo.Coaches", t => t.Coach_Id, cascadeDelete: true)
                .Index(t => t.Sport_Id)
                .Index(t => t.Coach_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SportsEvents", "SportId", "dbo.Sports");
            DropForeignKey("dbo.SportCoaches", "Coach_Id", "dbo.Coaches");
            DropForeignKey("dbo.SportCoaches", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.SportsEvents", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.ScheduleCoaches", "Coach_Id", "dbo.Coaches");
            DropForeignKey("dbo.ScheduleCoaches", "Schedule_Id", "dbo.Schedules");
            DropForeignKey("dbo.PlayerSportsEvents", "SportsEvent_Id", "dbo.SportsEvents");
            DropForeignKey("dbo.PlayerSportsEvents", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.GuardianPlayers", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.GuardianPlayers", "Guardian_Id", "dbo.Guardians");
            DropForeignKey("dbo.Players", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.SportsEvents", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.SportsEvents", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.SportsEvents", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.SportsEventCoaches", "Coach_Id", "dbo.Coaches");
            DropForeignKey("dbo.SportsEventCoaches", "SportsEvent_Id", "dbo.SportsEvents");
            DropForeignKey("dbo.SportsEvents", "AgeRangeId", "dbo.AgeRanges");
            DropForeignKey("dbo.LocationCoaches", "Coach_Id", "dbo.Coaches");
            DropForeignKey("dbo.LocationCoaches", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.GenderCoaches", "Coach_Id", "dbo.Coaches");
            DropForeignKey("dbo.GenderCoaches", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.CoachAgeRanges", "AgeRange_Id", "dbo.AgeRanges");
            DropForeignKey("dbo.CoachAgeRanges", "Coach_Id", "dbo.Coaches");
            DropIndex("dbo.SportCoaches", new[] { "Coach_Id" });
            DropIndex("dbo.SportCoaches", new[] { "Sport_Id" });
            DropIndex("dbo.ScheduleCoaches", new[] { "Coach_Id" });
            DropIndex("dbo.ScheduleCoaches", new[] { "Schedule_Id" });
            DropIndex("dbo.PlayerSportsEvents", new[] { "SportsEvent_Id" });
            DropIndex("dbo.PlayerSportsEvents", new[] { "Player_Id" });
            DropIndex("dbo.GuardianPlayers", new[] { "Player_Id" });
            DropIndex("dbo.GuardianPlayers", new[] { "Guardian_Id" });
            DropIndex("dbo.SportsEventCoaches", new[] { "Coach_Id" });
            DropIndex("dbo.SportsEventCoaches", new[] { "SportsEvent_Id" });
            DropIndex("dbo.LocationCoaches", new[] { "Coach_Id" });
            DropIndex("dbo.LocationCoaches", new[] { "Location_Id" });
            DropIndex("dbo.GenderCoaches", new[] { "Coach_Id" });
            DropIndex("dbo.GenderCoaches", new[] { "Gender_Id" });
            DropIndex("dbo.CoachAgeRanges", new[] { "AgeRange_Id" });
            DropIndex("dbo.CoachAgeRanges", new[] { "Coach_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Players", new[] { "GenderId" });
            DropIndex("dbo.SportsEvents", new[] { "SportId" });
            DropIndex("dbo.SportsEvents", new[] { "ScheduleId" });
            DropIndex("dbo.SportsEvents", new[] { "OrganizerId" });
            DropIndex("dbo.SportsEvents", new[] { "LocationId" });
            DropIndex("dbo.SportsEvents", new[] { "GenderId" });
            DropIndex("dbo.SportsEvents", new[] { "AgeRangeId" });
            DropTable("dbo.SportCoaches");
            DropTable("dbo.ScheduleCoaches");
            DropTable("dbo.PlayerSportsEvents");
            DropTable("dbo.GuardianPlayers");
            DropTable("dbo.SportsEventCoaches");
            DropTable("dbo.LocationCoaches");
            DropTable("dbo.GenderCoaches");
            DropTable("dbo.CoachAgeRanges");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sports");
            DropTable("dbo.Schedules");
            DropTable("dbo.Guardians");
            DropTable("dbo.Players");
            DropTable("dbo.Organizers");
            DropTable("dbo.SportsEvents");
            DropTable("dbo.Locations");
            DropTable("dbo.Genders");
            DropTable("dbo.Coaches");
            DropTable("dbo.AgeRanges");
        }
    }
}
