namespace CatsMvcViewerApp.Models
{
    public class Cat
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int BreedId { get; set; }

        public Breed Breed { get; set; } = default!;

        public string Gender { get; set; } = default!;

        public bool IsVacinated { get; set; }

        public bool IsDeleted { get; set; }

        public byte[] ImagePath { get; set; } = default!;
    }

    public enum CatsGender
    {
        Male, Female
    }

}
