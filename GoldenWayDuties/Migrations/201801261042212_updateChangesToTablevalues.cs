namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateChangesToTablevalues : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Taskitems", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Taskitems", "StartDate", c => c.DateTime());
        }
    }
}
