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

namespace GameShopDA.Repository.SubCategoryRepository
{
    public class SubCategoryRepository : BaseRepository<SubCategory, BaseSearch>, ISubCategoryRepository
    {
        public SubCategoryRepository(DBContext dbContext) : base(dbContext)
        {
        }
    }
}
