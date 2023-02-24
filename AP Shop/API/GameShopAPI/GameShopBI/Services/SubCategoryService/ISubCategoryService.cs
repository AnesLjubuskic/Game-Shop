using GameShopBI.Services.BaseService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.SubCategoryService
{
    public interface ISubCategoryService:IBaseService<SubCategory,SubCategoryDto,BaseSearch>
    {
    }
}
