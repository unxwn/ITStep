namespace ASP_Meeting_5
{
    public class Employee
    {
        public string Position { get; set; } = default!;

        public string Company { get; set; } = default!;

        public Education Education { get; set; } = default!;
    }

    public class Education
    {
        public string Level { get; set; }  = default!;
        public string Institution { get; set; } = default!;

        public int GraduationYear { get; set; }
    }
}
