namespace Quiz.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddDurationToQuizResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizResults", "Duration", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuizResults", "Duration");
        }
    }
}
