namespace Inforcauthu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class g : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doibong", "chitietclb", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doibong", "chitietclb");
        }
    }
}
