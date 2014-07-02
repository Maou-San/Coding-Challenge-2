namespace Coding_Challenge_2
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class TlsDictionary
    {
        private readonly Dictionary<char[], int> dictionar = new Dictionary<char[], int>();

        public Tuple<char[], int>[] ArrayOfAllPairs
        {
            get
            {
                //To be modified s.t. the implementation is not visible --- make what follows next into a private method
                Tuple<char[], int>[] arrayTuples;
                var i = 0;
                var count = 0;
                var keyColl = dictionar.Keys;
                arrayTuples = new Tuple<char[], int>[keyColl.Count];
                foreach (var s in keyColl)
                {
                    dictionar.TryGetValue(s, out count);
                    arrayTuples[i] = Tuple.Create(s, count);
                    i += 1;
                }
                return arrayTuples;
            }
        }

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
            if (ContainsTls(word))
            {
                var count = 0;
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

    internal class ChallengeSolver
    {
        private readonly string file = "";

        public ChallengeSolver(string fileName)
        {
            file = fileName;
        }

        private string ReadFile
        {
            get { return File.ReadAllText(file); }
        }
    }

    internal class Program
    {
        public string FileName = @"E:\Github\Coding Challenge 2\tls.txt";
        private static void Main(string[] args) {}
    }
}