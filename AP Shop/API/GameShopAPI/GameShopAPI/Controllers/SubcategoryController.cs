
using GameShopBI.Services.SubCategoryService;
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
    public class SubcategoryController : BaseController<SubCategory,SubCategoryDto,BaseSearch>
    {
       public ISubCategoryService _subcategoryService { get; set; }
       public SubcategoryController(ISubCategoryService subcategoryService):base(subcategoryService)
       {
           _subcategoryService = subcategoryService;
       }
       
       [HttpGet]
       public async Task<IActionResult> Get()
       {
           var categories = await _subcategoryService.GetAll();
           return Ok(categories);
       }
       
       [HttpPost, Authorize(Roles = "Admin")]
       public async Task<IActionResult> Add(SubCategoryDto subcategory)
       {
           await _subcategoryService.Insert(subcategory);
           return Ok(subcategory);
       }
       
       [HttpPut, Authorize(Roles = "Admin")]
       public IActionResult Update(SubCategoryDto subcategory)
       {
           _subcategoryService.Update(subcategory);
           return Ok(subcategory);
       }
    }
}
