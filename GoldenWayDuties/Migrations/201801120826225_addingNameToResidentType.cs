namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingNameToResidentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResidentTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResidentTypes", "Name");
        }
    }
}
