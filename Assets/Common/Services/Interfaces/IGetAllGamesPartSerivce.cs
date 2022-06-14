using Assets.Common.Models;
using System.Collections.Generic;

namespace Assets.Common.Services.Interfaces
{
    public interface IGetAllGamesPartSerivce
    {
        List<GameModel> GetGames();
    }
}
