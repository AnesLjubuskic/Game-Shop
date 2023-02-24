using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.Repository.Base
{
    public interface IBaseRepository<T, TSearch>
        where T : class  where TSearch : BaseSearch 
    {
        Task<List<T>> GetAll(TSearch search=null);
        Task<T> GetById(int id);
        Task<T> Insert(T insert);
        T Update(T update);
        Task<List<T>> Delete(int id);
    }
}
