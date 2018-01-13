namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateResidentTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE ResidentTypes SET Name = 'Parent',   DurataionInMonths = 240,   DiscountRate = 5 WHERE Id = 1");
            Sql("UPDATE ResidentTypes SET Name = 'Teenager', DurataionInMonths = 144,   DiscountRate = 15 WHERE Id = 2");
            Sql("UPDATE ResidentTypes SET Name = 'Child' ,   DurataionInMonths = 60,    DiscountRate = 25 WHERE Id = 3");
            Sql("UPDATE ResidentTypes SET Name = 'Toddler',  DurataionInMonths = 24,    DiscountRate = 50 WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
