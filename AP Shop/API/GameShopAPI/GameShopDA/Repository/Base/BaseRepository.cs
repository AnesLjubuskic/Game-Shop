using AutoMapper;
using GameShopDA;
using GameShopDA.DBModels;
using GameShopDA.SearchModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.Repository.Base
{
    public class BaseRepository<T, TSearch> : IBaseRepository<T,TSearch>
        where T : class  where TSearch : BaseSearch
    {
        protected DBContext _dbContext { get; set; }
        protected DbSet<T> _dbSet;
        public BaseRepository(DBContext dbContext) {
            _dbContext= dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async virtual Task<List<T>> GetAll(TSearch search)
        {
            var data = _dbSet.AsQueryable();
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                data = data.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }
            return data.ToList();
        }

        public async virtual Task<T> GetById(int id)
        {
            var entity= await _dbSet.FindAsync(id);
            if (entity == null) return null;
            return entity;
        }

        public async virtual Task<T> Insert(T insert)
        {
            await _dbSet.AddAsync(insert);
            await _dbContext.SaveChangesAsync();
            return insert;
        }

        public virtual T Update(T update)
        {
            _dbSet.Update(update);
             _dbContext.SaveChanges();
             return update;          
        }

        public async virtual Task<List<T>> Delete(int id)
        {
            var deleteItem=await _dbSet.FindAsync(id);
            if (deleteItem == null) return null;
            _dbSet.Remove(deleteItem);
            await _dbContext.SaveChangesAsync();
            return await _dbSet.ToListAsync();
        }

    }
}
