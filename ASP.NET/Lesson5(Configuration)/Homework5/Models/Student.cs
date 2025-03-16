namespace Homework5.Models
{
    public class Student
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; }
        public List<string> Subjects { get; set; } = new List<string>();
    }
}
