namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        AwardId = c.Int(nullable: false),
                        SubmissionId = c.Int(nullable: false),
                        AwardName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AwardId)
                .ForeignKey("dbo.Submissions", t => t.AwardId)
                .Index(t => t.AwardId);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        CompetitionId = c.Int(nullable: false),
                        Picture = c.String(nullable: false),
                        SubmissionName = c.String(nullable: false),
                        UpdatedAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        CreatorId = c.String(maxLength: 128),
                        Description = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .Index(t => t.CompetitionId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false, identity: true),
                        CompetitionName = c.String(nullable: false),
                        CreatorId = c.String(maxLength: 128),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        CancelAt = c.DateTime(),
                        Image = c.String(nullable: false),
                        Slide = c.String(),
                        Description = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        AwardDetail = c.String(),
                        IsSlide = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompetitionId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserCode = c.String(),
                        Email = c.String(nullable: false, maxLength: 256),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Avatar = c.String(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdateAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UserType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        MarkId = c.Int(nullable: false, identity: true),
                        SubmissionId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                        Marks = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Competition_CompetitionId = c.Int(),
                    })
                .PrimaryKey(t => t.MarkId)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: true)
                .ForeignKey("dbo.Competitions", t => t.Competition_CompetitionId)
                .Index(t => t.SubmissionId)
                .Index(t => t.AccountId)
                .Index(t => t.Competition_CompetitionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CompetitionAccounts",
                c => new
                    {
                        Competition_CompetitionId = c.Int(nullable: false),
                        Account_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Competition_CompetitionId, t.Account_Id })
                .ForeignKey("dbo.Competitions", t => t.Competition_CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Competition_CompetitionId)
                .Index(t => t.Account_Id);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Awards", "AwardId", "dbo.Submissions");
            DropForeignKey("dbo.Submissions", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Submissions", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Marks", "Competition_CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Marks", "SubmissionId", "dbo.Submissions");
            DropForeignKey("dbo.Marks", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompetitionAccounts", "Account_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompetitionAccounts", "Competition_CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Competitions", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CompetitionAccounts", new[] { "Account_Id" });
            DropIndex("dbo.CompetitionAccounts", new[] { "Competition_CompetitionId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Marks", new[] { "Competition_CompetitionId" });
            DropIndex("dbo.Marks", new[] { "AccountId" });
            DropIndex("dbo.Marks", new[] { "SubmissionId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Competitions", new[] { "CreatorId" });
            DropIndex("dbo.Submissions", new[] { "CreatorId" });
            DropIndex("dbo.Submissions", new[] { "CompetitionId" });
            DropIndex("dbo.Awards", new[] { "AwardId" });
            DropTable("dbo.CompetitionAccounts");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Marks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Competitions");
            DropTable("dbo.Submissions");
            DropTable("dbo.Awards");
        }
    }
}
