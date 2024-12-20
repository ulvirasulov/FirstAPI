using AutoMapper;
using BlogApp.API.DTO;
using BlogApp.Core.Entities;

namespace BlogApp.API.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}
