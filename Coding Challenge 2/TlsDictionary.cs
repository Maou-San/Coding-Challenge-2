namespace Coding_Challenge_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class TlsDictionary
    {
        private readonly Dictionary<string, int> dictionary = new Dictionary<string, int>();

        //adds a word to the dictionary if it is a tls
        public void AddWord(string word)
        {
            if (IsTls(word))
            {
                AddTls(word);
            }
        }

        public int CountTls(string word)
        {
            if (!ContainsTls(word))
            {
                return 0;
            }
            var count = 0;
            dictionary.TryGetValue(word, out count);
            return count;
        }

        //prints the tls with the exact numberOfOccurrences
        public void PrintTls(int numberOfOccurrences)
        {
            var tlsCollection = dictionary.Keys;
            foreach (var tls in tlsCollection.Where(tls => dictionary[tls] == numberOfOccurrences)) {
                Console.Write(tls);
                Console.Write(" ");
                Console.Write(dictionary[tls]);
                Console.Write("\n");
            }
            Console.Read();
        }

        //checks whether a string is in the tls dictionary
        public bool ContainsTls(string word)
        {
            return dictionary.ContainsKey(word);
        }

        private static bool IsTls(string word)
        {
            return (word.Length == 3 && OnlyLowerLetters(word));
        }
        private static bool OnlyLowerLetters(string word)
        {
            return (IsLowerLetter(word[0]) && IsLowerLetter(word[1]) && IsLowerLetter(word[2]));
        }
        private static bool IsLowerLetter(char letter)
        {
            return ('a' <= letter && letter <= 'z');
        }
        private void AddTls(string word)
        {
            if (ContainsTls(word))
            {
                dictionary[word] += 1;
            }
            else
            {
                dictionary.Add(word, 1);
            }
        }
    }
}