namespace Coding_Challenge_2
{
    using System.Collections.Generic;

    internal class TlsDictionary
    {
        private Dictionary<char[], int> dictionar;

        public bool ContainsTls(char[] word)
        {
            return (IsTls(word) && dictionar.ContainsKey(word));
        }

        public void AddTls(char[] word)
        {
            if (ContainsTls(word))
            {
                var count = 0;
                dictionar.TryGetValue(word, out count);
                count += 1;
                dictionar.Remove(word);
                dictionar.Add(word, count);
            }
            else
            {
                dictionar.Add(word, 1);
            }
        }

        public int CountTls(char[] word)
        {
            var count = 0;
            if (ContainsTls(word))
            {
                dictionar.TryGetValue(word, out count);
                return count;
            }
            return 0;
        }

        private bool IsTls(char[] word)
        {
            return (word.Length == 3 && OnlyLowerLetters(word));
        }

        private bool OnlyLowerLetters(char[] word)
        {
            return (IsLowerLetter(word[0]) && IsLowerLetter(word[1]) && IsLowerLetter(word[2]));
        }

        private bool IsLowerLetter(char letter)
        {
            return ('a' <= letter && letter <= 'z');
        }
    }

    internal class ChallengeSolver {}

    internal class Program
    {
        private static void Main(string[] args) {}
    }
}