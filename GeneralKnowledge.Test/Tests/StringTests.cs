using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzza";
            var uniqueChars = new List<Char>();
            var uniqueCharsAndCount = word.GetUniqueCharsAndCount(out uniqueChars);
            Console.WriteLine(string.Format("Unique Character: ({0}).", string.Join(", ", uniqueChars)));
            Console.WriteLine(string.Format("Number of Occurrences: ({0}).", string.Join("; ", uniqueCharsAndCount.Select(x => $"{x.Key}={x.Value}"))));
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string stringOne, string stringTwo)
        {
            var firstString = new Dictionary<char, int>();
            if (stringOne.Length != stringTwo.Length)
            {
                return false;
            }

            foreach (var character in stringOne.ToLower())
            {
                if (firstString.ContainsKey(character))
                {
                    firstString[character]++;
                }
                else
                {
                    firstString[character] = 1;
                }
            }

            foreach (var character in stringTwo.ToLower())
            {
                if (firstString.ContainsKey(character))
                {
                    firstString[character]--;
                }
                else
                {
                    return false;
                }
            }

            return !(firstString.Any(x => x.Value > 0));
        }

        public static Dictionary<char,int> GetUniqueCharsAndCount(this string word, out List<char> uniqueChars)
		{
            var dictionary = word.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            uniqueChars = dictionary.Where(x => x.Value == 1).Select(x => x.Key).ToList();
            return dictionary;
		}
    }
}
