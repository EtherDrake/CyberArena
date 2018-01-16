namespace CyberArena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Nickname = c.String(nullable: false),
                        Discipline = c.String(),
                        MMR = c.Int(nullable: false),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Team");
            DropTable("dbo.Player");
        }
    }
}
