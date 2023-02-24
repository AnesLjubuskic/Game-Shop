using AutoMapper;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<UserGame, UserGameDto>().ReverseMap();
        }
    }
}
