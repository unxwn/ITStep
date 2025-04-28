using CatsMvcViewerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CatsMvcViewerApp.Data
{
    public static class CatsSeeder
    {
        public static async Task SeedData(
            IServiceProvider provider,
            IWebHostEnvironment environment)
        {
            //DbContextOptionsBuilder<CatsContext> builder = new DbContextOptionsBuilder<CatsContext>(); ;
            //builder.UseSqlServer("");
            DbContextOptions<CatsContext> options = provider
                .GetRequiredService<DbContextOptions<CatsContext>>();
            using(CatsContext context = new CatsContext(options))
            {
                if(!context.Breeds.Any())
                {
                    Breed breed1 = new Breed
                    {
                        BreedName = "Скоттіш страйт"
                    };
                    Breed breed2 = new Breed
                    {
                        BreedName = "Абесинська"
                    };
                    Breed breed3 = new Breed
                    {
                        BreedName = "Бенгальська"
                    };
                    Breed breed4 = new Breed { BreedName = "Мейн Кун" };
                    await context.Breeds.AddRangeAsync(breed1, breed2, breed3,
                        breed4);
                    string webRootPath = environment.WebRootPath;
                    string filePath1 = $"{webRootPath}\\images\\scottish.jpg";
                    string filePath2 = $"{webRootPath}\\images\\abessian.jpg";
                    byte[] photo1 = File.ReadAllBytes(filePath1);
                    byte[] photo2 = File.ReadAllBytes(filePath2);
                    Cat cat1 = new Cat
                    {
                        Name = "Василь",
                        Gender = CatsGender.Male.ToString(),
                        Breed = breed1,
                        IsVacinated = true,
                        ImagePath = photo1
                    };
                    Cat cat2 = new Cat
                    {
                        Name = "Вітамінка",
                        Gender = CatsGender.Female.ToString(),
                        Breed = breed2,
                        IsVacinated = false,
                        ImagePath = photo2
                    };
                    await context.Cats.AddRangeAsync(cat1, cat2);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
