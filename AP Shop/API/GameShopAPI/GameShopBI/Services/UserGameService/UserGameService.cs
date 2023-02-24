using AutoMapper;
using GameShopBI.Services.BaseService;
using GameShopBI.Services.EmailService;
using GameShopBI.Services.GameService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.Repository.UserGameRepository;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.UserGameService
{
    public class UserGameService:BaseService<UserGame,UserGameDto,BaseSearch>,IUserGameService
    {
        public IUserGameRepository _userGameRepository { get; set; }
        public IGameService _gameService { get; set; }
        public IEmailService _emailService { get; set; }
        public Timer? timer = null;
        public UserGameService(IMapper mapper,IUserGameRepository userGameRepository,IEmailService emailService,IGameService gameService):base(mapper,userGameRepository) 
        {
            _userGameRepository= userGameRepository;
            _emailService= emailService;
            _gameService= gameService;
        }

        public async Task<List<UserGameDto>> GetByUserId(int id)
        {
            var data = await _userGameRepository.GetByUserId(id);
            var dbData= _mapper.Map<List<UserGameDto>>(data);
            return dbData;
        }

        public async Task<List<UserGameDto>> GetPurchaseHistory(int userId)
        {
            var data = await _userGameRepository.GetPurchaseHistory(userId);
            var dbData=_mapper.Map<List<UserGameDto>>(data);
            return dbData;
        }
        public async Task<List<UserGameDto>> DeleteFromCart(int id,int userId)
        {
            var list = await _userGameRepository.DeleteFromCart(id,userId);
            return _mapper.Map<List<UserGameDto>>(list);
        }

        public List<UserGameDto> DeleteAllFromCart(int userId)
        {
            var list = _userGameRepository.DeleteAllFromCart(userId);
            return _mapper.Map<List<UserGameDto>>(list);
        }

        public async Task<List<UserGameDto>> GetByUserIdOrder(int id)
        {
            var buyCheck = true;
            var data = await _userGameRepository.GetByUserIdOrder(id,buyCheck);
            var dbData = _mapper.Map<List<UserGameDto>>(data);
            return dbData;
        }

        public async Task<UserGameDto> InsertGameUser(UserGameDto insert)
        {
            EmailHandler(insert);
            var insertDB = _mapper.Map<UserGame>(insert);
            await _baseRepository.Insert(insertDB);
            return insert;
        }

        private void EmailHandler(UserGameDto? insert)
        {
            
            var email = new EmailDto()
            {
                To = "anes.ljubuskic@authoritypartners.com",
                Subject = "Item in cart",
                Body = "<h1>An item has been added to cart!</h1>"
            };
            _emailService.SendEmail(email);
        }

        public List<UserGameDto> UpdateOrder(List<UserGameDto> games)
        {
            var mapped = _mapper.Map<List<UserGame>>(games);
            _userGameRepository.UpdateOrder(mapped);
            return games;
        }
    }
}
