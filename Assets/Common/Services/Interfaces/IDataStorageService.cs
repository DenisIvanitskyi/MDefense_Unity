namespace Assets.Common.Services.Interfaces
{
    public interface IDataStorageService<T>
    {
        T Current { get; set; }

        void Save();

        void Load();
    }
}
