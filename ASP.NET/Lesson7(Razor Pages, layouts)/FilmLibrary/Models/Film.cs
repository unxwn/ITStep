using System.ComponentModel.DataAnnotations;

namespace FilmLibrary.Models
{
    public class Film
    {
        [Required(ErrorMessage = "Назва фільму обов’язкова.")]
        [MinLength(3, ErrorMessage = "Назва повинна містити не менше 3 символів.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ім'я режисера обов’язкове.")]
        [MinLength(3, ErrorMessage = "Ім'я режисера повинно містити не менше 3 символів.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Стиль фільму обов’язковий.")]
        public string Genre { get; set; }

        [Display(Name = "Короткий опис")]
        [MinLength(6, ErrorMessage = "Опис повинен містити не менше 6 символів.")]
        public string Description { get; set; }
    }
}
