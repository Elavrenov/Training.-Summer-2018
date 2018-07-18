namespace RepositoryLogic
{
    public interface IRepository
    {
        void Save(string id, string person, decimal value);
        string GetById(string id);
        string GetPerson();
        string GetId();
        void Create();
        void Update(string id, decimal value);
    }
}
