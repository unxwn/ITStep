namespace Quiz.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangedTypeOfScoreInQuizResult : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuizResults", "Score", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuizResults", "Score", c => c.Int(nullable: false));
        }
    }
}
