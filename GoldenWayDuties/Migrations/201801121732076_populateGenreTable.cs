namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreTable : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Cooking')");
            //Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Kitchen')");
            //Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Gardening')");
            //Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Laundry')");
            //Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Cleaning')");
            //Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Leisure/Entertainment')");

            //Sql("INSERT INTO Genres (Name) VALUES ( 'Cooking')");
            //Sql("INSERT INTO Genres ( Name) VALUES ( 'Kitchen')");
            //Sql("INSERT INTO Genres ( Name) VALUES ( 'Gardening')");
            //Sql("INSERT INTO Genres ( Name) VALUES ( 'Laundry')");
            //Sql("INSERT INTO Genres ( Name) VALUES ( 'Cleaning')");
            //Sql("INSERT INTO Genres ( Name) VALUES ( 'Leisure/Entertainment')");
        }
        
        public override void Down()
        {
        }
    }
}
