namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotatuionstoCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Owners", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Owners", "Name", c => c.String());
        }
    }
}
