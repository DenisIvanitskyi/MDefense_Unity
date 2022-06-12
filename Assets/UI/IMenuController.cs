
namespace Assets.UI
{
    public interface IMenuController
    {
        void OnNewGameTextChanged();

        void DisplayMenu();

        void DisplayNewGame();

        void DisplaySaveGames();

        void DisplaySettings();

        void Exit();

        string GetNewGameName();

        string GetTextFromSaveGamesSearchTb();
    }
}
