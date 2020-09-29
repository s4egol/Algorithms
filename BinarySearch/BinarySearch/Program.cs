using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        private const int wordCount = 128;

        static void Main(string[] args)
        {
            var random = new Random();

            var sortedWords = GenerateWords(wordCount).OrderBy(x => x).ToList();
            var searchWordOffset = random.Next(0, sortedWords.Count - 1);
            var searchWord = sortedWords[searchWordOffset];

            var index = FindIndexByBinarySearch(sortedWords, searchWord);

            Console.WriteLine($"String: {searchWord} in position {index}");
            Console.ReadKey();
        }

        static int? FindIndexByBinarySearch(IEnumerable<string> sortedWords, string searchWord)
        {
            var minIndex = 0;
            var maxIndex = sortedWords.Count() - 1;
            var sortedWordList = sortedWords.ToList();

            while(minIndex <= maxIndex)
            {
                var middle = minIndex + ((maxIndex - minIndex) / 2);
                var result = string.Compare(sortedWordList[middle], searchWord, StringComparison.OrdinalIgnoreCase);

                if (result == 0) return middle;
                if (result > 0) maxIndex = middle--;
                if (result < 0) minIndex = middle++;
            }

            return null;
        }

        static IEnumerable<string> GenerateWords(int count)
        {
            var words = new List<string>();
            var letters = "qwertyuiopasdfghjklzxcvbnm";
            var random = new Random();

            for(int i = 0; i < count; i++)
            {
                var word = string.Empty;
                var wordLetterCount = random.Next(1, 50);
                
                for(int j = 0; j < wordLetterCount; j++)
                {
                    var letterOffset = random.Next(0, letters.Length - 1);
                    word += letters[letterOffset];
                }

                words.Add(word);
            }

            return words;
        }
    }

    
}
