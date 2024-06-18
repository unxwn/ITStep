using System.Collections.Generic;

namespace QuizApp.Models
{
    public class Topic
    {
        public string Name { get; set; }
        public Dictionary<string, List<string>> Questions { get; set; }
        public int QuestionCount { get; set; }
    }
}
