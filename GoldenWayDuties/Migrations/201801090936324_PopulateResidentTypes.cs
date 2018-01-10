namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateResidentTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ResidentTypes (Id, SignUpFee, DurataionInMonths, DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO ResidentTypes (Id, SignUpFee, DurataionInMonths, DiscountRate) VALUES (2,0,1,0)");
            Sql("INSERT INTO ResidentTypes (Id, SignUpFee, DurataionInMonths, DiscountRate) VALUES (3,0,3,0)");
            Sql("INSERT INTO ResidentTypes (Id, SignUpFee, DurataionInMonths, DiscountRate) VALUES (4,0,12,0)");
        }
        
        public override void Down()
        {
        }
    }
}
