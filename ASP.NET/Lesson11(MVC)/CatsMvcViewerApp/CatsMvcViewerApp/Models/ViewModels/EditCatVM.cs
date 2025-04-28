using CatsMvcViewerApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatsMvcViewerApp.Models.ViewModels
{
    public class EditCatVM
    {
        public CatDTO CatDTO { get; set; } = default!;

        public SelectList Breeds { get; set; } = default!;

        public SelectList Genders { get; set; } = default!;

        public byte[] Image { get; set; } = default!;
    }
}
