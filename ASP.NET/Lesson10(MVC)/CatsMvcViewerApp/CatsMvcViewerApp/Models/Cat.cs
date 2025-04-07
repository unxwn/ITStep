namespace CatsMvcViewerApp.Models
{
    public class Cat
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int BreedId { get; set; }

        public Breed Breed { get; set; } = default!;

        public  CatsGender Gender { get; set; }

        public bool IsVacinated { get; set; }

        public bool IsDeleted { get; set; }

        public string ImagePath { get; set; } = default!;
    }

    public enum CatsGender
    {
        Male, Female
    }

}
