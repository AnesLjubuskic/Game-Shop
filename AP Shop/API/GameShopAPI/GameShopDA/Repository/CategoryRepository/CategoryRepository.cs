using AutoMapper;
using GameShopDA.Repository.Base;
using GameShopDA;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShopDA.SearchModels;

namespace GameShopDA.Repository.CategoryRepository
{
    public class CategoryRepository : BaseRepository<Category, BaseSearch>, ICategoryRepository
    {
        public CategoryRepository(DBContext dbContext) : base(dbContext)
        {
        }
    }
}
