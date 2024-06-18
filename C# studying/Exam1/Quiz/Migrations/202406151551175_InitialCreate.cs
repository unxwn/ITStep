namespace Quiz.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizResults",
                c => new
                    {
                        QuizResultId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Topic = c.String(),
                        Score = c.Int(nullable: false),
                        DateTaken = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.QuizResultId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizResults", "UserId", "dbo.Users");
            DropIndex("dbo.QuizResults", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.QuizResults");
        }
    }
}
