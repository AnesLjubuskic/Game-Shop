using GameShopDA.Repository.Base;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShopDA.SearchModels;

namespace GameShopDA.Repository.SubCategoryRepository
{
    public interface ISubCategoryRepository:IBaseRepository<SubCategory,BaseSearch>
    {
    }
}
