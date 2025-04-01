using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_Meeting_7.Models
{
    public class Author
    {
        public int Id { get; set; }
        //[BindProperty]
        [Display(Name = "Рік народження")]
        public int YearOfBirth { get; set; }
        //[BindProperty]
        [Required]
        [MinLength(3)]
        [Display(Name ="Ім'я")]
        public string Firstname { get; set; } = string.Empty;
        //[BindProperty]
        [Display(Name = "Прізвище")]
        public string Surname { get; set; } = string.Empty;
    }
}
