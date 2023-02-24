using AutoMapper;
using GameShopBI.Services.BaseService;
using GameShopDA.Repository.Base;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShopDA.Repository.CategoryRepository;
using GameShopDA.SearchModels;

namespace GameShopBI.Services.CategoryService
{
    public class CategoryService : BaseService<Category, CategoryDto, BaseSearch>, ICategoryService
    {
        public CategoryService(IMapper mapper, ICategoryRepository baseRepository) : base(mapper, baseRepository)
        {
        }
    }
}
