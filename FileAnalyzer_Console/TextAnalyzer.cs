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

            List<string> filteredWords = new List<string>(); // dizinin boyutu sabittir, biz burada filtrelenmiş metinin kaç elemanlı olduğunu bilmediğimiz için dinamik boyutlu olan liste oluşturduk.

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

            int uniqueWordCount = filteredWords.Distinct().Count();  // distinct ile tekrar eden kelimeleri siliyoruz.

            // tekrar eden kelimeleri ve bu kelimelerin kaç defa tektrar ettiklerinin sayısını, en çok tekrar edenden en az tekrar edene doğru sıralanmış şekilde konsola yazdıracağımız kısım burası.
            //-----------------------------------------------------------------
            Dictionary<string, int> wordAndCounts = new Dictionary<string, int>(); // burada dictionary kullanıyoruz bu sayede kelimeler ve tekrar sayıları bir arada tutabiliyoruz. tekrar eden kelime sayısına göre tekrar sayısı yazdığımız için Dictionary<string, int> yapısını kullandık.

            foreach (var word in filteredWords) // filtrelenmiş kelimelerin bulunduğu listedeki her bir elemanı yani kelimeyi, word isimli olarak döngüye sokuyoruz.
            {
                if (wordAndCounts.ContainsKey(word)) // sözlükteki kelime, test ettiğimiz kelimeyle uyuşuyorsa kelimenin Value değerini yani bu sözlükteki int değerini 1 artırıyoruz. Sözlüğün yapısı: Dictionary<TKey, TValue>
                    wordAndCounts[word]++;
                else
                    wordAndCounts[word] = 1; // yoksa tekrar sayısını 1 yapıyoruz çünkü test ettiğimiz kelimeye ilk defa rastladık.
            }

            var sortedWordCounts = wordAndCounts.OrderByDescending(wordAndValue => wordAndValue.Value); // Tekrar eden kelimeleri büyükten küçüğe sıralamak için sıralama algoritmaları kullanmam gerekicekti. Onun yerine Bu LINQ yapısını kullandım. bir LINQ metodu olan OrderByDescending wordAndCounts daki her bir elemanı wordAndValue ismiyle alıyor ve büyükten küçüğe doğru sıralıyor. ve bu sıralanmış halini sortedWordCounts a atıyoruz.
            //-------------------------------------------------------------------

            Console.WriteLine($"Character count: {charCount}");
            Console.WriteLine($"Line count: {lineCount}");
            Console.WriteLine($"Unique word count: {uniqueWordCount}");
            Console.WriteLine("");
            Console.WriteLine("repetitive words");
            Console.WriteLine("----------------");

            foreach (var repetitiveWords in sortedWordCounts)
            {
                if (repetitiveWords.Value > 1) // kelimenin tekrar sayısı 1 ise almıyoruz çünkü mantıken kelime 1 defa geçiyorsa tekrar etmiyordur.
                {
                    Console.WriteLine($"{repetitiveWords.Value}  {repetitiveWords.Key}");
                }
            }
        }
    }
}
