using System;

namespace QuizApp.Models
{
    public class QuizResult
    {
        public int QuizResultId { get; set; }
        public int UserId { get; set; }
        public string Topic { get; set; }
        public string Score { get; set; }
        public DateTime DateTaken { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
