using GameShopBI.Services.BaseService;
using GameShopDA.DBModels;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.GameService
{
    public interface IGameService : IBaseService<Game, GameDto, GameSearch>
    {
        List<GameDto> GetByGameIds(List<int> gameId);
        List<GameDto> UpdateGameList(List<GameDto> games);

    }
}
