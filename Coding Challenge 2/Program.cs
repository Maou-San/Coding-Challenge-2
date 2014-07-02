namespace Coding_Challenge_2
{
    using System;
    using System.Collections.Generic;

    internal class TlsDictionary
    {
        private Dictionary<char[], int> dictionar;

        public bool ContainsTls(char[] word)
        {
            return (isTls(word) && dictionar.ContainsKey(word));
        }

        public void AddTls(char[] word)
        {
            if (isTls(word))
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
            else
            {
                throw new Exception("Not a TLS");
            }
        }

        public int CountTls(char[] word)
        {
            if (isTls(word))
            {
                var count = 0;
                if (ContainsTls(word))
                {
                    dictionar.TryGetValue(word, out count);
                    return count;
                }
                return 0;
            }
            throw new Exception("Not a TLS");
        }

        private bool isTls(char[] word)
        {
            return word.Length == 3;
        }
    }

    internal class Program
    {
        private static void Main(string[] args) {}
    }
}