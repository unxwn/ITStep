using System.ComponentModel.DataAnnotations;

namespace CatsMvcViewerApp.Models.DTOs
{
    public class BreedDTO
    {
        public int Id { get; set; }
        [Display(Name = "Порода")]
        [MinLength(6)]
        public string BreedName { get; set; } = default!;
    }
}
