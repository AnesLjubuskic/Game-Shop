using GameShopBI.Services.BaseService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.UserGameService
{
    public interface IUserGameService:IBaseService<UserGame,UserGameDto,BaseSearch>
    {
        Task<List<UserGameDto>> GetByUserId(int id);
        Task<List<UserGameDto>> GetByUserIdOrder(int id);
        Task<List<UserGameDto>> GetPurchaseHistory(int userId);
        Task<List<UserGameDto>> DeleteFromCart(int id, int userId);
        List<UserGameDto> DeleteAllFromCart(int userId);
        Task<UserGameDto> InsertGameUser(UserGameDto insert);
        List<UserGameDto> UpdateOrder(List<UserGameDto> games);

    }
}
