using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;


namespace FoodRecipe.Model
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Food, VideoDTO>();
            CreateMap<VideoDTO, Food>();
        }
    }
}
