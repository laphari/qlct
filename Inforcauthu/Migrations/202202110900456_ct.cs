namespace Inforcauthu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inforcauthu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.DateTime(nullable: false),
                        Country = c.String(),
                        inforcaothap = c.String(),
                        Salary = c.String(),
                        Value = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inforcauthu");
        }
    }
}
