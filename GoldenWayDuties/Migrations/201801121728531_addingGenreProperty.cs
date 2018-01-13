namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingGenreProperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Taskitems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        GenreId = c.Byte(nullable: false),
                        Genre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Genre_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taskitems", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Taskitems", new[] { "Genre_Id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Taskitems");
        }
    }
}
