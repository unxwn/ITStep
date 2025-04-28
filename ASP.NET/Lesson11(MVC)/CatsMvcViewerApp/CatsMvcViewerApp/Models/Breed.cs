using System.ComponentModel.DataAnnotations;

namespace CatsMvcViewerApp.Models
{
    public class Breed
    {
        public int Id { get; set; }
        [Display(Name = "Порода")]
        [MinLength(6)]
        public string BreedName { get; set; } = default!;

        //public ICollection<Cat> Cats { get; set; } = default!;
    }
}
