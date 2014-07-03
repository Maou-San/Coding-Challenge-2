namespace CC2_Linq
{
    using System;
    using System.IO;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //var readf = File.ReadAllText(@"E:\GitHub\Coding Challenge 2\CC2 Linq\tls.txt").ToLower();
            //var range = Enumerable.Range(0, readf.Length - 2);
            //var subStrings = range.Select(element => readf.Substring(element, 3));
            //var filtered = subStrings.Where(item => (('a' <= item[0] && item[0] <= 'z') && ('a' <= item[1] && item[1] <= 'z') && ('a' <= item[2] && item[2] <= 'z')));
            //var distinct = filtered.Distinct();
            foreach (var str in Enumerable.Range(0, File.ReadAllText(@"E:\GitHub\Coding Challenge 2\CC2 Linq\tls.txt").ToLower().Length - 2)
                                          .Select(element => File.ReadAllText(@"E:\GitHub\Coding Challenge 2\CC2 Linq\tls.txt").ToLower().Substring(element, 3))
                                          .Where(item => (('a' <= item[0] && item[0] <= 'z') && ('a' <= item[1] && item[1] <= 'z') && ('a' <= item[2] && item[2] <= 'z'))).Distinct())
            {
                Console.Write(str);
                Console.Write(" ");
                Console.WriteLine(Enumerable.Range(0, File.ReadAllText(@"E:\GitHub\Coding Challenge 2\CC2 Linq\tls.txt").ToLower().Length - 2)
                                            .Select(element => File.ReadAllText(@"E:\GitHub\Coding Challenge 2\CC2 Linq\tls.txt").ToLower().Substring(element, 3))
                                            .Where(item => (('a' <= item[0] && item[0] <= 'z') && ('a' <= item[1] && item[1] <= 'z') && ('a' <= item[2] && item[2] <= 'z'))).Count(el => el == str));
            }
            Console.Read();
        }
    }
}