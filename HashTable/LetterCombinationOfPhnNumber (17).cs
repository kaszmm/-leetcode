using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class LetterCombinationOfPhnNumber__17_
    {
        public static IList<string> letterCombination(string digits)
        {
            if (string.IsNullOrEmpty(digits)) return new List<string>();
            string[] letters = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            var queue = new Queue<string>();
            queue.Enqueue("");
            foreach (var item in digits)
            {
                var count = queue.Count();
                while (count > 0)
                {
                    var comb = queue.Dequeue();
                    foreach (var newItem in letters[item - '2'])
                    {
                        queue.Enqueue(comb + newItem);
                    }
                    count--;
                }

            }
            return queue.ToList();
        }
        public static List<String> combinations = new List<string>();
        public static Dictionary<char, string> letters = new Dictionary<char, string>() {
                { '2', "abc" }, { '3', "def" },{ '4', "ghi" },{ '5', "jkl" },{ '6', "mno" },{ '7', "pqrs" },{ '8', "tuv" },{ '9', "wxyz" }
            };
        public static string phoneDigits;
        public static IList<string> LetterCombinations(string digits)
        {
            phoneDigits = digits;
            //if the input is empty . return the empty combination array 
            if (digits.Length == 0) return combinations;

            //Initiate Backtracking with an empty path and starting index of zero
            BackTrac(0, new StringBuilder());
            return combinations;
        }

        private static void BackTrac(int index, StringBuilder path)
        {
            if (path.Length == phoneDigits.Length)
            {
                combinations.Add(path.ToString());
                return; // Backtrack
            }
            string phoneDigitLetters;
            // Get the letters that the current digit maps to
            if (letters.TryGetValue(phoneDigits[index], out phoneDigitLetters))
            {
                foreach (char letter in phoneDigitLetters)
                {
                    path.Append(letter);
                    BackTrac(index + 1, path);
                    path.Remove(path.Length - 1, 1);
                }
            }
        }
    }
}
