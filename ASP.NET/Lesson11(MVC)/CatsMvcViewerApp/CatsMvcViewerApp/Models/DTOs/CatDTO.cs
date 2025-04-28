using System.ComponentModel.DataAnnotations;

namespace CatsMvcViewerApp.Models.DTOs
{
    public class CatDTO
    {
        //DTO - Data Transfer Object
        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        public string Name { get; set; } = default!;
        [Display(Name = "Порода")]
        public int BreedId { get; set; }
        [Display(Name = "Стать")]
        public CatsGender Gender { get; set; }
        [Display(Name = "Статус вакцинації")]
        public bool IsVacinated { get; set; }
    }
}
