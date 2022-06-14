using Assets.Common.Services.Interfaces;

namespace Assets.Common.Services
{
    public class ValidationService : IValidationGameNameService
    {
        public bool ValidatateGameName(string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }
}
