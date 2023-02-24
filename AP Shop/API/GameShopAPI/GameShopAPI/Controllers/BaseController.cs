using GameShopBI.Services.BaseService;
using GameShopDA.SearchModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TDto,TSearch> : ControllerBase where T : class where TSearch :  BaseSearch where TDto: class
    {       
        public IBaseService<T,TDto,TSearch> _baseService { get; set; }
        public BaseController(IBaseService<T,TDto,TSearch> baseService)
        { 
            _baseService = baseService;
        }


    }
}
