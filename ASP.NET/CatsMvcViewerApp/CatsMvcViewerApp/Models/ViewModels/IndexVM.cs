using CatsMvcViewerApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatsMvcViewerApp.Models.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<CatDTO> Cats { get; set; } = default!;

        public SelectList Breeds { get; set; } = default!;

        public string? Search { get; set; } = default!;

        public int BreedId { get; set; }
    }
}
