using System;

namespace Assets.Services.Base
{
    public interface IGameService : IGetAllGamesPartSerivce, IGameQuitPartService
    {
        Guid CreateNewGame(string gameName);

        void DeleteGame(Guid id);
    }
}
