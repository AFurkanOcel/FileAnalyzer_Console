using System;
using System.Collections.Generic;
using System.Linq;

namespace FileAnalyzer_Console
{
    public class TextAnalyzer
    {
        public void AnalyzeFile(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new Exception("File is empty!");
            }

            int charCount = content.Length;
            int lineCount = content.Split('\n').Length;

            string[] conjunctions = { "ve", "ile", "ama", "ancak" };
            string[] words = content.Split(' ', '\n', '\r');

            List<string> filteredWords = new List<string>();

            foreach (string word in words)
            {
                string lowercaseWord = word.ToLower();

                int number;
                bool isNumber = int.TryParse(lowercaseWord, out number);

                if (!string.IsNullOrWhiteSpace(lowercaseWord) && !conjunctions.Contains(lowercaseWord) && !isNumber)
                {
                    filteredWords.Add(lowercaseWord);
                }
            }

            int uniqueWordCount = filteredWords.Distinct().Count();
            Dictionary<string, int> wordAndCounts = new Dictionary<string, int>();

            foreach (var word in filteredWords)
            {
                if (wordAndCounts.ContainsKey(word))
                    wordAndCounts[word]++;
                else
                    wordAndCounts[word] = 1;
            }

            var sortedWordCounts = wordAndCounts.OrderByDescending(wordAndValue => wordAndValue.Value);

            Console.WriteLine($"Character count: {charCount}");
            Console.WriteLine($"Line count: {lineCount}");
            Console.WriteLine($"Unique word count: {uniqueWordCount}");
            Console.WriteLine("");
            Console.WriteLine("repetitive words");
            Console.WriteLine("----------------");

            foreach (var repetitiveWords in sortedWordCounts)
            {
                if (repetitiveWords.Value > 1)
                {
                    Console.WriteLine($"{repetitiveWords.Value}  {repetitiveWords.Key}");
                }
            }
        }
    }
}
