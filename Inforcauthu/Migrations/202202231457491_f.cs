namespace Inforcauthu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doibong", "Namthanhlap", c => c.String());
            AddColumn("dbo.Doibong", "Chutichclb", c => c.String());
            AddColumn("dbo.Doibong", "fan", c => c.String());
            AddColumn("dbo.Doibong", "logo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doibong", "logo");
            DropColumn("dbo.Doibong", "fan");
            DropColumn("dbo.Doibong", "Chutichclb");
            DropColumn("dbo.Doibong", "Namthanhlap");
        }
    }
}
