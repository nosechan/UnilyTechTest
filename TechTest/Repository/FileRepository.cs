namespace TechTest.Repository
{
    public class FileRepository : IFileRepository
    {
        public void AddMessage(string id, string date, string message)
        {
            
            using (TextWriter textWriter = new StreamWriter(File.Open("logMessage.log", FileMode.OpenOrCreate, FileAccess.Write)))
            {
                textWriter.WriteLine($"{id}\t{date}\t{message.Replace("\t", "\\t").Replace("\n", "\\n").Replace("\r", "\\r")}");
            }
        }
    }
}
