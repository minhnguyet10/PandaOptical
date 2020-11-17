namespace Website_Panda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "IdRole", "dbo.Roles");
            DropForeignKey("dbo.Users", "GroupID", "dbo.UserGroups");
            DropIndex("dbo.Users", new[] { "GroupID" });
            DropIndex("dbo.Users", new[] { "IdRole" });
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        UserGroupID = c.String(nullable: false, maxLength: 20),
                        RoleName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.UserGroupID, t.RoleName });
            
            AddColumn("dbo.Users", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
            DropTable("dbo.Credentials");
            CreateIndex("dbo.Users", "IdRole");
            CreateIndex("dbo.Users", "GroupID");
            AddForeignKey("dbo.Users", "GroupID", "dbo.UserGroups", "GroupID");
            AddForeignKey("dbo.Users", "IdRole", "dbo.Roles", "IDRole", cascadeDelete: true);
        }
    }
}
