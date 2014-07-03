namespace Coding_Challenge_2
{
    using System;

    internal class Program
    {
        public static string FileName = @"E:\Github\Coding Challenge 2\Coding Challenge 2\tls.txt";

        private static void Main(string[] args)
        {
            var numberOfOccurrences = 99;
            numberOfOccurrences = int.Parse(Console.ReadLine());
            var solver = new ChallengeSolver(FileName, numberOfOccurrences);
            solver.ExecuteSolver();
        }
    }
}