using AutoMapper;
using CatsMvcViewerApp.Models;
using CatsMvcViewerApp.Models.DTOs;

namespace CatsMvcViewerApp.Profiles
{
    public class BreedProfile : Profile
    {
        public BreedProfile() {
            CreateMap<Breed, BreedDTO>()
                .ReverseMap();
        }
    }
}
