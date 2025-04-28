using System.ComponentModel.DataAnnotations;

namespace CatsMvcViewerApp.Models
{
    public class Breed
    {
        public int Id { get; set; }
       
        public string BreedName { get; set; } = default!;

        public ICollection<Cat> Cats { get; set; } = default!;
    }
}
