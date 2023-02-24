
using GameShopBI.Services.UserService;
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
    public class UserController : BaseController<User,UserDto, UserSearch>
    {
        public IUserService _userService { get; set; }
        public UserController(IUserService userService):base(userService) 
        {
            _userService = userService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> Get()
        {
            return Ok(await _userService.GetAll());
        }
      
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDto user)
        {

            return Ok(_userService.CreatePasswordHash(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto user)
        {
            var usersDB = await _userService.GetAll();
            var emailExists = false;
            foreach (var userIn in usersDB)
            {
                if (userIn.Email == user.Email)
                {
                    emailExists = true;
                }
            }
            if (!emailExists)
                return BadRequest("Invalid data!");
            if (!await _userService.VerifyHash(user))
            {
                return BadRequest("Invalid data!");
            }
            var token = _userService.CreateToken(user);
            return Ok(token);
        }

        [HttpGet("GetByEmail"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            return Ok(await _userService.GetByEmail(email));
        }
    }
}
