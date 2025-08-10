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
                throw new Exception("File is empty!");
            }

            int charCount = content.Length; // metindeki karakter sayısını hesaplar.
            int lineCount = content.Split('\n').Length; // metni satır satır ayırıp, satır sayısını hesaplar.

            // sayılar ve bağlaçlar analize dahil edilmeyecek.
            string[] conjunctions = { "ve", "ile", "ama", "ancak" }; // sayılmayacak bağlaçlar.
            string[] words = content.Split(' ', '\n', '\r'); // boşluk, \n veya \r gördüğünde kelimeyi bitirir.

            List<string> filteredWords = new List<string>(); // dizinin boyutu sabittir, biz burada filtrelenmiş metinin kaç elemanlı olduğunu bilmediğimiz için dinamik boyutlu liste oluşturduk.

            foreach (string word in words) // metin words dizisinin içerisinde kelime kelime tutuluyor, "string word in words" denince bu dizideki her bir eleman yani kelime, string türünde word isimli değişkene tek tek atanıyor. 
            {
                string lowercaseWord = word.ToLower(); // kelimelerin tüm harflerini küçük harfe çeviriyoruz. Bu sayede hello ve Helllo kelimelerinin farklı kelime olarak sayılmasına engel oluyoruz.

                int number;
                bool isNumber = int.TryParse(lowercaseWord, out number); // tryparse ile kelimeyi int e çevirmeyi dener, eğer başarırsa int değerini başaramazsa da 0 değerini number ın içine atar ve satırın sonucu buna göre true veya false döner, burada bu boolean değeri isnumber ın içine atıyoruz.

                if (!string.IsNullOrWhiteSpace(lowercaseWord) && !conjunctions.Contains(lowercaseWord) && !isNumber)
                {
                    filteredWords.Add(lowercaseWord);// kelime boş değilse, bağlaç değilse veya sayı değilse listeye eklenir.
                }
            }

            int uniqueWordCount = filteredWords.Distinct().Count();  // distinct tekrar eden kelimeleri siler.ile tekrar eden kelimeleri siliyoruz.
            Console.WriteLine($"Character count: {charCount}");
            Console.WriteLine($"Line count: {lineCount}");
            Console.WriteLine($"Unique word count: {uniqueWordCount}");
        }
    }
}
