using AutoMapper;
using CatsMvcViewerApp.Models;
using CatsMvcViewerApp.Models.DTOs;

namespace CatsMvcViewerApp.Profiles
{
    public class CatProfile : Profile
    {
        public CatProfile() {
            CreateMap<Cat, CatDTO>().ReverseMap();
        }
    }
}
