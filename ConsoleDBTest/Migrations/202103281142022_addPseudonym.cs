namespace ConsoleDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPseudonym : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Pseudonym", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Pseudonym");
        }
    }
}
