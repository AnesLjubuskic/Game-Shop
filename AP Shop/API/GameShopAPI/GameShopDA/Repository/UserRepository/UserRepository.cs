using AutoMapper;
using GameShopDA.Repository.Base;
using GameShopDA;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.Repository.UserRepository
{
    public class UserRepository : BaseRepository<User,UserSearch>, IUserRepository
    {
        public DbContext _dbContext { get; set; }
        public UserRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _dbSet.Where(x => x.Email == email).FirstOrDefaultAsync();
            return user;
        }
    }
}
