using System;

namespace Assets.Services.Base
{
    public interface ICreateNewGame
    {
        Guid CreateNewGame(string gameName);
    }
}
