
namespace Assets.Services.Base
{
    public interface IDataStorageService<T>
    {
        T Current { get; set; }

        void Save();

        void Load();
    }
}
