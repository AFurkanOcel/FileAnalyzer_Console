using System.IO;

namespace FileAnalyzer_Console.FileReaders
{
    public class TxtFileReader
    {
        public string ReadText(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            StreamReader reader = new StreamReader(fs);

            string content = reader.ReadToEnd();

            reader.Close();
            fs.Close();

            return content;
        }
    }
}
