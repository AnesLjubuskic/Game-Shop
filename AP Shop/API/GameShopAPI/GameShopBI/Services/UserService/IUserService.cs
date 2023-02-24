using GameShopBI.Services.BaseService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.UserService
{
    public interface IUserService:IBaseService<User,UserDto,UserSearch>
    {
        User CreatePasswordHash(UserDto user);
        Task<bool> VerifyHash(UserLoginDto user);
        UserJWTDto CreateToken(UserLoginDto user);
        Task<User> GetByEmail(string email);
    }
}
