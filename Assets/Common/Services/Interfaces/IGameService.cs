using System;

namespace Assets.Common.Services.Interfaces
{
    public interface IGameService : IGetAllGamesPartSerivce, IGameQuitPartService
    {
        Guid CreateNewGame(string gameName);

        void DeleteGame(Guid id);
    }
}
