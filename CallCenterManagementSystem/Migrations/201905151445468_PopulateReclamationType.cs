namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateReclamationType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ReclamationTypes (Name,Description) VALUES ('Dead on Arrival','Before 24h')");
            Sql("INSERT INTO ReclamationTypes (Name,Description) VALUES ('Normal Type','After 24h')");
        }
        
        public override void Down()
        {
        }
    }
}
