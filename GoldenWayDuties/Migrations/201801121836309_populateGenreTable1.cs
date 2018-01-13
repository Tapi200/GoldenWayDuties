namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ( 'Cooking')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Kitchen')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Gardening')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Laundry')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Cleaning')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Leisure/Entertainment')");
        }

        public override void Down()
        {
        }
    }
}
