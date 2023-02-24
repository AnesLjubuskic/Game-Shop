using GameShopDA.Repository.Base;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.Repository.CategoryRepository
{
    public interface ICategoryRepository : IBaseRepository<Category,BaseSearch>
    {
    }
}
