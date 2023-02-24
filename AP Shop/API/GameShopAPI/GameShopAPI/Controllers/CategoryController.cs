using GameShopBI.Services.CategoryService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<Category,CategoryDto, BaseSearch>
    {
        public ICategoryService _categoryService { get; set; }
        public CategoryController(ICategoryService categoryService):base(categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]BaseSearch search)
        {
            var categories = await _categoryService.GetAll(search);
            return Ok(categories);
        }
       
   

        [HttpPost,Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            await _categoryService.Insert(category);
            return Ok(category);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public IActionResult Update(CategoryDto category)
        {
            _categoryService.Update(category);
            return Ok(category);
        }
    }
}

