using GameShopDA.DBModels;
using GameShopDA.Repository.Base;
using GameShopDA.SearchModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.Repository.UserGameRepository
{
    public class UserGameRepository:BaseRepository<UserGame,BaseSearch>,IUserGameRepository
    {
        public UserGameRepository(DBContext db):base(db)
        {

        }

        public async Task<List<UserGame>> GetByUserId(int id)
        {
            return await _dbSet.Where(x => x.UserId == id && x.Purchased==false).ToListAsync();
        }

        public async Task<List<UserGame>> GetPurchaseHistory(int userId)
        {
            return await _dbSet.Where(x=>x.UserId== userId && x.Purchased).ToListAsync();
        }

        public async Task<List<UserGame>> DeleteFromCart(int id,int userId)
        {
            var deleteItem = await _dbSet.Where(x=>x.gameId==id && x.UserId==userId).FirstOrDefaultAsync();
            if (deleteItem == null) return null;
            _dbSet.Remove(deleteItem);
            await _dbContext.SaveChangesAsync();
            return await _dbSet.ToListAsync();
        }

        public List<UserGame> DeleteAllFromCart(int userId)
        {
            var data= _dbSet.Where(x=>x.UserId==userId && x.Purchased==false ).ToList();
            _dbSet.RemoveRange(data);
            _dbContext.SaveChanges();
            return data;
        }

        public async Task<List<UserGame>> GetByUserIdOrder(int id, bool buyCheck)
        {
            return await _dbSet.Where(x => x.UserId == id && x.BuyCheck==buyCheck && x.Purchased==false).ToListAsync();
        }

        public List<UserGame> UpdateOrder(List<UserGame> games)
        {
             _dbSet.UpdateRange(games);
            _dbContext.SaveChanges();
            return games;
        }
    }
}
