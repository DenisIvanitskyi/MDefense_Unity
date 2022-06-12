using Assets.Services.Base;

namespace Assets.Services
{
    public class ValidationService : IValidationGameNameService
    {
        public bool ValidatateGameName(string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }
}
