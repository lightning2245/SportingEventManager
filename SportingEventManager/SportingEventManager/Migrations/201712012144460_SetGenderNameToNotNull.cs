namespace SportingEventManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGenderNameToNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genders", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genders", "Name", c => c.String(maxLength: 50));
        }
    }
}
