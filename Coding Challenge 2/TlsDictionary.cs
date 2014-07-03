namespace Coding_Challenge_2
{
    using System;
    using System.Collections.Generic;

    internal class TlsDictionary
    {
        private readonly Dictionary<string, int> dictionar = new Dictionary<string, int>();

        //Creates an array of all pairs (made from tls and number of occurrences)
        private Tuple<string, int>[] ArrayOfAllPairs
        {
            get
            {
                var i = 0;
                var keyColl = dictionar.Keys;
                var arrayOfTuples = new Tuple<string, int>[keyColl.Count];
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
            dictionar.TryGetValue(word, out count);
            return count;
        }

        //prints the tls with the exact numberOfOccurrences
        public void PrintTls(int numberOfOccurrences)
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
                Console.Write(arrayOfAllTuples[i].Item2);
                Console.Write("\n");
            }
            Console.Read();
        }

        //checks whether a string is in the tls dictionary
        public bool ContainsTls(string word)
        {
            return dictionar.ContainsKey(word);
        }

        private void AddTls(string word)
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

        private bool IsTls(string word)
        {
            return (word.Length == 3 && OnlyLowerLetters(word));
        }

        private bool OnlyLowerLetters(string word)
        {
            return (IsLowerLetter(word[0]) && IsLowerLetter(word[1]) && IsLowerLetter(word[2]));
        }

        private bool IsLowerLetter(char letter)
        {
            return ('a' <= letter && letter <= 'z');
        }
    }
}