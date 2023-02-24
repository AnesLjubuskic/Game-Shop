using AutoMapper;
using GameShopDA.Repository.Base;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.BaseService
{
    public class BaseService<T, TDto, TSearch> : IBaseService<T, TDto, TSearch>
        where T : class where TDto : class where TSearch : BaseSearch
    {
        public IMapper _mapper { get; set; } 
        public IBaseRepository<T,TSearch> _baseRepository { get; set; }
        public BaseService(IMapper mapper,IBaseRepository<T,TSearch> baseRepository)
        {
            _mapper= mapper;
            _baseRepository= baseRepository;
        }
        public async virtual Task<List<TDto>> GetAll(TSearch search = null)
        {
             var data = await _baseRepository.GetAll(search);
            return _mapper.Map<List<TDto>>(data);
        }

        public async Task<TDto> GetById(int id)
        {
            var entity= await _baseRepository.GetById(id);
            return _mapper.Map<TDto>(entity);
        }

        public async virtual Task<TDto> Insert(TDto insert)
        {
            var insertDB=_mapper.Map<T>(insert);
            await _baseRepository.Insert(insertDB);
            return insert;
        }

        public TDto Update(TDto update)
        {
            var updateDB=_mapper.Map<T>(update);
            _baseRepository.Update(updateDB);
            return update;
        }

        public async Task<List<TDto>> Delete(int id)
        {
            var list=await _baseRepository.Delete(id);
            return _mapper.Map<List<TDto>>(list);
        }

    }
}
