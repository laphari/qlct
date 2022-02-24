namespace Inforcauthu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doibong",
                c => new
                    {
                        IDclub = c.Int(nullable: false, identity: true),
                        Nameclub = c.String(),
                    })
                .PrimaryKey(t => t.IDclub);
            
            AddColumn("dbo.Inforcauthu", "Doibong_IDclub", c => c.Int());
            AddForeignKey("dbo.Inforcauthu", "Doibong_IDclub", "dbo.Doibong", "IDclub");
            CreateIndex("dbo.Inforcauthu", "Doibong_IDclub");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Inforcauthu", new[] { "Doibong_IDclub" });
            DropForeignKey("dbo.Inforcauthu", "Doibong_IDclub", "dbo.Doibong");
            DropColumn("dbo.Inforcauthu", "Doibong_IDclub");
            DropTable("dbo.Doibong");
        }
    }
}
