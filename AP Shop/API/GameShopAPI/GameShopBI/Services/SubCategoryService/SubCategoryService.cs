using AutoMapper;
using GameShopBI.Services.BaseService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.Repository.SubCategoryRepository;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.SubCategoryService
{
    public class SubCategoryService : BaseService<SubCategory,SubCategoryDto,BaseSearch>,ISubCategoryService
    {
        public SubCategoryService(IMapper mapper,ISubCategoryRepository subCategoryRepository):base(mapper,subCategoryRepository) { }
    }
}
