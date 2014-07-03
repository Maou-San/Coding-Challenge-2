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
                var i = 0;
                var keyColl = dictionar.Keys;
                var arrayOfTuples = new Tuple<char[], int>[keyColl.Count];
                foreach (var s in keyColl)
                {
                    var count = 0;
                    dictionar.TryGetValue(s, out count);
                    arrayOfTuples[i] = Tuple.Create(s, count);
                    i += 1;
                }
                return arrayOfTuples;
            }
        }

        public bool ContainsTls(char[] word)
        {
            return (IsTls(word) && dictionar.ContainsKey(word));
        }

        public void AddWord(char[] word)
        {
            if (IsTls(word))
            {
                AddTls(word);
            }
        }

        public int CountTls(char[] word)
        {
            if (!ContainsTls(word))
            {
                return 0;
            }
            var count = 0;
            dictionar.TryGetValue(word, out count);
            return count;
        }

        private void AddTls(char[] word)
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
        private readonly string textOfFile = "";
        private readonly int numberOfOccurrences = 1;

        public ChallengeSolver(string fileName, int minimal)
        {
            textOfFile = fileName;
            numberOfOccurrences = minimal;
        }

        private string ReadFile
        {
            get { return File.ReadAllText(textOfFile); }
        }

        public void ExecuteSolver()
        {
            Execute();
        }

        private void Execute()
        {
            var tlsContainer = new TlsDictionary();
            var lengthOfFile = textOfFile.Length;
            var currentPosition = 0;
            while (currentPosition < lengthOfFile - 2)
            {
                var triplet = getTriplet(currentPosition);
                tlsContainer.AddWord(triplet);
                currentPosition += 1;
            }
            printTls(numberOfOccurrences);
        }

        private void printTls(int exactNumberOfOccurrences) {}

        private char[] getTriplet(int currentPosition)
        {
            throw new NotImplementedException();
        }
    }

    internal class Program
    {
        public string FileName = @"E:\Github\Coding Challenge 2\tls.txt";

        private static void Main(string[] args)
        {
            var NumberOfOccurrences = 1;
            NumberOfOccurrences = Console.Read();
            var solver = new ChallengeSolver(FileName, NumberOfOccurrences);
            solver.ExecuteSolver();
        }
    }
}