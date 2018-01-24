namespace GoldenWayDuties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateChangesToDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Taskitems", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Taskitems", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Taskitems", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Taskitems", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
