namespace ExamWork.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Director",
                c => new
                {
                    DirectorID = c.Int(nullable: false, identity: true),
                    DirectorName = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.DirectorID);

            CreateTable(
                "dbo.Movie",
                c => new
                {
                    MovieID = c.Int(nullable: false, identity: true),
                    MovieName = c.String(nullable: false, maxLength: 50),
                    MoviePrice = c.Double(nullable: true),
                    GenreID = c.Int(nullable: false),
                    DirectorID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.MovieID)
                .ForeignKey("dbo.Director", t => t.DirectorID, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.GenreID)
                .Index(t => t.DirectorID);

            CreateTable(
                "dbo.Genre",
                c => new
                {
                    GenreID = c.Int(nullable: false, identity: true),
                    GenreType = c.String(nullable: false),
                })
                .PrimaryKey(t => t.GenreID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Movie", "GenreID", "dbo.Genre");
            DropForeignKey("dbo.Movie", "DirectorID", "dbo.Director");
            DropIndex("dbo.Movie", new[] { "DirectorID" });
            DropIndex("dbo.Movie", new[] { "GenreID" });
            DropTable("dbo.Genre");
            DropTable("dbo.Movie");
            DropTable("dbo.Director");
        }
    }
}

