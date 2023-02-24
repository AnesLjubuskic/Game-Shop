using GameShopDA.DBModels;
using GameShopDA.Repository.Base;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.Repository.UserGameRepository
{
    public interface IUserGameRepository:IBaseRepository<UserGame,BaseSearch>
    {
        Task<List<UserGame>> GetByUserId(int id);
        Task<List<UserGame>> GetByUserIdOrder(int id, bool buyCheck);
        Task<List<UserGame>> GetPurchaseHistory(int userId);
        Task<List<UserGame>> DeleteFromCart(int id, int userId);
        List<UserGame> DeleteAllFromCart(int userId);
        List<UserGame> UpdateOrder(List<UserGame> games);

    }
}
