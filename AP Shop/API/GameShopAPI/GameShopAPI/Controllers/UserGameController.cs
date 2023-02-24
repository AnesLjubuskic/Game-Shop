using GameShopBI.Services.EmailService;
using GameShopBI.Services.GameService;
using GameShopBI.Services.UserGameService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace GameShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameController : BaseController<UserGame,UserGameDto,BaseSearch>
    {
        public IUserGameService _userGameService { get; set; }
        public IGameService _gameService { get; set; }
        public IEmailService _emailService { get; set; }
        public UserGameController(IUserGameService userGameService,IEmailService emailService,IGameService gameService):base(userGameService) 
        {
            _userGameService= userGameService;
            _gameService= gameService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BaseSearch search)
        {
            var categories = await _userGameService.GetAll(search);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var game = await _userGameService.GetByUserId(id);
            return Ok(game);
        }

        [HttpGet("GetOrderById{id}")]
        public async Task<IActionResult> GetByOrderId(int id)
        {
            var game= await _userGameService.GetByUserIdOrder(id);
            return Ok(game);
        }

        [HttpGet("GetPurchaseHistory{id}")]
        public async Task<IActionResult> GetPurchaseHistory(int id)
        {
            var game = await _userGameService.GetPurchaseHistory(id);
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserGameDto game)
        {
           /* var timer = new PeriodicTimer(TimeSpan.FromSeconds(20));
            var email = new EmailDto()
            {
                To = "anes.ljubuskic@authoritypartners.com",
                Subject = "Test",
                Body = "<h1>Test 20 seconds</h1>"
            };
            while (await timer.WaitForNextTickAsync())
            {
                _emailService.SendEmail(email);
            }*/
            game.Purchased = false;
            await _userGameService.InsertGameUser(game);
            return Ok(game);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id,int userId)
        {
            var list = await _userGameService.DeleteFromCart(id,userId);
            return Ok(list);
        }

        [HttpPut]
        public IActionResult Update(UserGameDto game)
        {
            var data= _userGameService.Update(game);
            return Ok(data);
        }

        [HttpPut("UpdateRange")]

        public IActionResult UpdateRange(List<UserGameDto> games)
        {
            var data=_userGameService.UpdateOrder(games);
            return Ok(data);
        }



        [HttpDelete("DeleteAllFromCart")]
        public  IActionResult DeleteAllFromSelect(int userId)
        {
            var data=_userGameService.DeleteAllFromCart(userId);
            return Ok(data);
        }

        [HttpPost("SendEmail")]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
