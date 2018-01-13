namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixGenreProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Taskitems", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Taskitems", new[] { "Genre_Id" });
            DropColumn("dbo.Taskitems", "GenreId");
            RenameColumn(table: "dbo.Taskitems", name: "Genre_Id", newName: "GenreId");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Taskitems", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Taskitems", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Taskitems", "GenreId");
            AddForeignKey("dbo.Taskitems", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taskitems", "GenreId", "dbo.Genres");
            DropIndex("dbo.Taskitems", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Taskitems", "GenreId", c => c.Int());
            AlterColumn("dbo.Taskitems", "Name", c => c.String());
            AddPrimaryKey("dbo.Genres", "Id");
            RenameColumn(table: "dbo.Taskitems", name: "GenreId", newName: "Genre_Id");
            AddColumn("dbo.Taskitems", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Taskitems", "Genre_Id");
            AddForeignKey("dbo.Taskitems", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
