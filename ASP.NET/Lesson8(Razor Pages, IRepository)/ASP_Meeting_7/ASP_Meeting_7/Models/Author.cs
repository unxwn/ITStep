using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_Meeting_7.Models
{
    public class Author
    {
        public int Id { get; set; }
        //[BindProperty]
        public int YearOfBirth { get; set; }
        //[BindProperty]
        [Required]
        [MinLength(6)]
        public string Firstname { get; set; } = string.Empty;
        //[BindProperty]
        public string Surname { get; set; } = string.Empty;
    }
}
