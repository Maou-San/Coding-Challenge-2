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

        public void printTls(int numberOfOccurrences)
        {
            var arrayOfAllTuples = ArrayOfAllPairs;
            var lengthOfArray = arrayOfAllTuples.Length;
            for (var i = 0; i < lengthOfArray; i++)
            {
                if (arrayOfAllTuples[i].Item2 != numberOfOccurrences)
                {
                    continue;
                }
                Console.Write(arrayOfAllTuples[i].Item1);
                Console.Write(" ");
            }
            Console.Read();
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
        private readonly string nameOfFile = string.Empty;
        private readonly int numberOfOccurrences = 1;
        private string textOfFile;

        public ChallengeSolver(string fileName, int minimal)
        {
            nameOfFile = fileName;
            numberOfOccurrences = minimal;
        }

        private string ReadFile
        {
            get { return File.ReadAllText(nameOfFile); }
        }

        public void ExecuteSolver()
        {
            Execute();
        }

        private void Execute()
        {
            var tlsContainer = new TlsDictionary();
            textOfFile = ReadFile.ToLower();
            var lengthOfFile = textOfFile.Length;
            var currentPosition = 0;
            while (currentPosition < lengthOfFile - 2)
            {
                var triplet = GetTriplet(currentPosition);
                tlsContainer.AddWord(triplet);
                currentPosition += 1;
            }
            tlsContainer.printTls(numberOfOccurrences);
        }

        private char[] GetTriplet(int currentPosition)
        {
            var threeLetters = new char[3];
            threeLetters[0] = textOfFile[currentPosition];
            threeLetters[1] = textOfFile[currentPosition + 1];
            threeLetters[2] = textOfFile[currentPosition + 2];
            return threeLetters;
        }
    }

    internal class Program
    {
        public static string FileName = @"E:\Github\Coding Challenge 2\Coding Challenge 2\tls.txt";

        private static void Main(string[] args)
        {
            var numberOfOccurrences = 99;
            //numberOfOccurrences = Console.Read();
            var solver = new ChallengeSolver(FileName, numberOfOccurrences);
            solver.ExecuteSolver();
        }
    }
}