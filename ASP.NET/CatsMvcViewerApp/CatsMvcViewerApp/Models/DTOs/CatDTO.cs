using System.ComponentModel.DataAnnotations;

namespace CatsMvcViewerApp.Models.DTOs
{
    public class CatDTO
    {
        //DTO - Data Transfer Object
        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        public string Name { get; set; } = default!;
        
        public int BreedId { get; set; }
        [Display(Name = "Стать")]
        public CatsGender Gender { get; set; }
        [Display(Name = "Статус вакцинації")]
        public bool IsVacinated { get; set; }
        [Display(Name ="Фото")]
        public byte[]? ImagePath { get; set; }

        [Display(Name = "Порода")]
        public BreedDTO? Breed { get; set; }
    }
}
