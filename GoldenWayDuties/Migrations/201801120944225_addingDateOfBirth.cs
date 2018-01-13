namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Owners", "DateOfBirth");
        }
    }
}
