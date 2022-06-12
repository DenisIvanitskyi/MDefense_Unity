using Assets.Models;
using System.Collections.Generic;

namespace Assets.Services.Base
{
    public interface IGetAllGamesPartSerivce
    {
        List<GameModel> GetGames();
    }
}
