using GameShopDA.Repository.Base;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.Repository.UserRepository
{
    public interface IUserRepository:IBaseRepository<User,UserSearch>
    {
        Task<User> GetByEmail(string email);
    }
}
