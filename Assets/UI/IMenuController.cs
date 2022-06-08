
namespace Assets.UI
{
    public interface IMenuController
    {
        void DisplayMenu();

        void DisplayNewGame();

        void DisplaySaveGames();

        void DisplaySettings();

        void Exit();

        string GetNewGameName();
    }
}
