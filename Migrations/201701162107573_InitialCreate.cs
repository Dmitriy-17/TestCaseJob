namespace TestCaseJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        LeadreId = c.Int(),
                        Leader_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leaders", t => t.Leader_Id)
                .Index(t => t.Leader_Id);
            
            CreateTable(
                "dbo.Leaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Leader_Id", "dbo.Leaders");
            DropIndex("dbo.Employees", new[] { "Leader_Id" });
            DropTable("dbo.Leaders");
            DropTable("dbo.Employees");
        }
    }
}
