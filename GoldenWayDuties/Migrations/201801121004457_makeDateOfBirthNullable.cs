namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeDateOfBirthNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Owners", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Owners", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
