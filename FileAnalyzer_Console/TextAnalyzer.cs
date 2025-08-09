using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer_Console
{
    public class TextAnalyzer
    {
        public void Analyze(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) // dosya boş veya geçersiz mi kontrolü.
            {
                Console.WriteLine("File is empty or invalid!");
                return;
            }

            int charCount = content.Length; // metindeki karakter sayısını hesaplar.
            int lineCount = content.Split('\n').Length; // metni satır satır ayırıp, satır sayısını hesaplar.

            Console.WriteLine($"Character count: {charCount}");
            Console.WriteLine($"Line count: {lineCount}");
        }
    }
}
