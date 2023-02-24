using GameShopBI.Services.BaseService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.CategoryService
{
    public interface ICategoryService:IBaseService<Category,CategoryDto,BaseSearch>
    {

    }
}
