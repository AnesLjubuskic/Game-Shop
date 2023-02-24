using AutoMapper;
using GameShopBI.Services.BaseService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.Repository.GameRepository;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.GameService
{
    public class GameService : BaseService<Game,GameDto,GameSearch>,IGameService
    {
        public IMapper _mapper { get; set; }
        public IGameRepository _gameRepository { get; set; }
        public GameService(IMapper mapper, IGameRepository gameRepository):base(mapper, gameRepository) 
        {
            _gameRepository = gameRepository;
            _mapper= mapper;
        }

        public override async Task<List<GameDto>> GetAll(GameSearch search = null)
        {
            var data = await  _gameRepository.GetAll(search);
            var dto=_mapper.Map<List<GameDto>>(data);
            return dto;
        }

        public List<GameDto> GetByGameIds(List<int> gameId)
        {
            var data = _gameRepository.GetByGameIds(gameId);
            var dto = _mapper.Map<List<GameDto>>(data);
            return dto;
        }

        public List<GameDto> UpdateGameList(List<GameDto> games)
        {
            var mapped = _mapper.Map<List<Game>>(games);
            _gameRepository.UpdateGameList(mapped);
            return games;
        }
    }
}
