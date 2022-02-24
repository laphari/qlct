namespace Inforcauthu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inforcauthu", "Doibong_IDclub", "dbo.Doibong");
            DropIndex("dbo.Inforcauthu", new[] { "Doibong_IDclub" });
            RenameColumn(table: "dbo.Inforcauthu", name: "Doibong_IDclub", newName: "IDdoibongcauthu");
            AddForeignKey("dbo.Inforcauthu", "IDdoibongcauthu", "dbo.Doibong", "IDclub", cascadeDelete: true);
            CreateIndex("dbo.Inforcauthu", "IDdoibongcauthu");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Inforcauthu", new[] { "IDdoibongcauthu" });
            DropForeignKey("dbo.Inforcauthu", "IDdoibongcauthu", "dbo.Doibong");
            RenameColumn(table: "dbo.Inforcauthu", name: "IDdoibongcauthu", newName: "Doibong_IDclub");
            CreateIndex("dbo.Inforcauthu", "Doibong_IDclub");
            AddForeignKey("dbo.Inforcauthu", "Doibong_IDclub", "dbo.Doibong", "IDclub");
        }
    }
}
