using AutoMapper;
using GameShopDA.Repository.Base;
using GameShopDA;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShopDA.Repository.CategoryRepository;

namespace GameShopDA.Repository.GameRepository
{
    public class GameRepository : BaseRepository<Game,GameSearch>, IGameRepository
    {
        public DBContext _dbContext { get; set; }
        public GameRepository(DBContext dbContext,ICategoryRepository categoryRepository) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<List<Game>> GetAll(GameSearch search=null)
        {
            var data =  _dbContext.Games.Where(x=>x.SoftDelete==false).AsQueryable();
            if (search.Name != null)
            {
                //data=data.Where(x=>x.Name.ToLower() == search.Name.ToLower());
                // data =data.Contains(search.Name.ToLower());
                data = data.Where(x => x.Name.StartsWith(search.Name.ToLower()));
            }
            if(search.CategoryId!=null)
            {
                data=data.Where(x=>x.CategoryId==search.CategoryId);
            }
            if (search.SubcategoryId != null)
            {
                data = data.Where(x => x.SubCategoryId == search.SubcategoryId);
            }
            if (search.Platform != null)
            {
                data = data.Where(x => x.Platform == search.Platform);
            }
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                data = data.Skip((search.Page.Value-1) * search.PageSize.Value).Take(search.PageSize.Value);
            }
            if(search.Sort!=null)
            {
                if (search.Sort.ToLower() =="asc")
                {
                    data = data.OrderBy(x => x.Name);
                }
                if (search.Sort.ToLower() == "dsc")
                {
                    data = data.OrderByDescending(x => x.Name);
                }
            }
            return data.ToList();
        }

        public  List<Game> GetByGameIds(List<int> gameId)
        {
            var data =  _dbSet.Where(x => gameId.Contains(x.Id)).ToList();
            return data;
        }

        public List<Game> UpdateGameList(List<Game> games)
        {
            _dbSet.UpdateRange(games);
            _dbContext.SaveChanges();
            return games;
        }
    }
}
