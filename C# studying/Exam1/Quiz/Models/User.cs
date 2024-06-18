using System;
using System.Collections.Generic;

namespace QuizApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual List<QuizResult> QuizResults { get; set; }
    }
}
