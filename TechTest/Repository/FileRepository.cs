namespace TechTest.Repository
{
    public class FileRepository : IFileRepository
    {
        public void AddMessage(string id, DateTime date, string message)
        {
            string dateString = date.ToString("yyyy-MM-dd");
            using TextWriter textWriter = new StreamWriter(File.Open("logMessage.log", FileMode.OpenOrCreate, FileAccess.Write));
            textWriter.WriteLine($"{id}\t{dateString}\t{message.Replace("\t", "\\t").Replace("\n", "\\n").Replace("\r", "\\r")}");
        }
    }
}
