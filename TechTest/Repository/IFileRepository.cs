namespace TechTest.Repository
{
    public interface IFileRepository
    {
        void AddMessage(string id, DateTime date, string message);
    }
}
