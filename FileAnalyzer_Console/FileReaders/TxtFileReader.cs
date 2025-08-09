using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileAnalyzer_Console.FileReaders
{
    public class TxtFileReader
    {
        public string ReadText(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); // FileStram dosyanın ismini, yapılacak işlemin bilgisini ve verilen izin bilgilerini taşıyan bir kanal.

            StreamReader reader = new StreamReader(fs); // StreamReader fs ile tanımlanan dosyayı okuyor ve byte'ları stringlere çeviriyor.

            string content = reader.ReadToEnd(); // StreamReader ı Yukarıda tanımladık fakat burada çağırıyoruz. Stringe cevrilen tüm metin content değişkenine atanıyor.

            reader.Close();
            fs.Close();

            return content;
        }
    }
}
