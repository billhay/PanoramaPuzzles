namespace PanoramaPuzzle11
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using PanoramaPuzzleLib;

    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var all = Person.AllCombinations(Rules.IsValid);
            var outFile = Console.Out; // File.CreateText("GameResults.txt");
            {
                all
                    .AllCombinations(getPartionKey: x => x.Name)
                    .Where(Person.IsValid)
                    .ForEach(p => p.ForEach(outFile.WriteLine, null, outFile.WriteLine))
                    ;
            }

            outFile.Close();
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine("Elapsed time = {0}", watch.ElapsedMilliseconds/1000.0);
        }
    }
}