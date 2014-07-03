namespace Coding_Challenge_2
{
    using System.IO;

    internal class ChallengeSolver
    {
        private readonly string nameOfFile = string.Empty;
        private readonly int numberOfOccurrences = 1;
        private string textOfFile;

        //solves the problem for the the corresponding file and exact number of occurrences
        public ChallengeSolver(string fileName, int exactNumberOfOccurrences)
        {
            nameOfFile = fileName;
            numberOfOccurrences = exactNumberOfOccurrences;
        }

        private string ReadFile
        {
            get { return File.ReadAllText(nameOfFile); }
        }

        //solvers the problem
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
            tlsContainer.PrintTls(numberOfOccurrences);
        }

        //gets triplets from file
        private string GetTriplet(int currentPosition)
        {
            var threeLetters = new char[3];
            threeLetters[0] = textOfFile[currentPosition];
            threeLetters[1] = textOfFile[currentPosition + 1];
            threeLetters[2] = textOfFile[currentPosition + 2];
            return new string(threeLetters);
        }
    }
}