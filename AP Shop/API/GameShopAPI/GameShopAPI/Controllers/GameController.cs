using GameShopBI.Services.CategoryService;
using GameShopBI.Services.GameService;
using GameShopBI.Services.SubCategoryService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.Enum;
using GameShopDA.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseController<Game,GameDto,GameSearch>
    {
        public IGameService _gameService { get; set; }
        public ICategoryService _categoryService { get; set; }
        public ISubCategoryService _subCategoryService { get; set; }
        public GameController(IGameService gameService,ICategoryService categoryService,ISubCategoryService subCategoryService):base(gameService)
        {
            _gameService = gameService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GameSearch search=null)
        {
            var games = await _gameService.GetAll(search);
            foreach(var game in games)
            {
                var category = await _categoryService.GetById(game.CategoryId);
                var subcategory = await _subCategoryService.GetById(game.SubCategoryId);
                game.PlatformName = game.Platform.ToString();
                game.CategoryName = category.CategoryName;
                game.SubcategoryName = subcategory.SubCategoryName;
            }
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _gameService.GetById(id);
            var category = await _categoryService.GetById(game.CategoryId);
            var subcategory = await _subCategoryService.GetById(game.SubCategoryId);
            game.PlatformName = game.Platform.ToString();
            game.CategoryName = category.CategoryName;
            game.SubcategoryName = subcategory.SubCategoryName;
            return Ok(game);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(GameDto game)
        {
            await _gameService.Insert(game);
            return Ok(game);
        }

        [HttpPut, Authorize]
        public IActionResult Update(GameDto game)
        {
            _gameService.Update(game);
            return Ok(game);
        }

        [HttpDelete("{id}"), Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id) 
        {
            var list=await _gameService.Delete(id);
            return Ok(list);
        }

        [HttpGet("GetPaging")]
        public ActionResult GetPaging()
        {
            var numberOfGames = _gameService.GetAll().Result.Count();
            return Ok(numberOfGames/10);
        }

        [HttpGet("GetGamesById")]
        public ActionResult GetGamesById([FromQuery]List<int> gamesId)
        {
            var games=_gameService.GetByGameIds(gamesId);
            return Ok(games);
        }

        [HttpPut("UpdateRangeOfGames")]

        public IActionResult UpdateRange(List<GameDto> games)
        {
            var data = _gameService.UpdateGameList(games);
            return Ok(data);
        }

    }
}
