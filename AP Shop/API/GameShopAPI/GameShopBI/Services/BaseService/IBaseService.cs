using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.BaseService
{
    public interface IBaseService<T,TDto,TSearch>
        where T : class where TDto: class where TSearch : BaseSearch
    {
        Task<List<TDto>> GetAll(TSearch search = null);
        Task<TDto> GetById(int id);
        Task<TDto> Insert(TDto insert);
        TDto Update(TDto update);
        Task<List<TDto>> Delete(int id);
    }
}
