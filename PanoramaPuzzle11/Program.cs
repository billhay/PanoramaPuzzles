namespace PanoramaPuzzle11
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using PanoramaPuzzleLib;

    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Person> all = Person.AllCombinations(Rules.IsValid);
            var outFile = Console.Out; // File.CreateText("GameResults.txt");

            all
                .AllCombinations(getPartionKey: x => x.Name)
                .Where(Person.IsValid)
                .ForEach(p => p.ForEach(outFile.WriteLine, null, outFile.WriteLine));

            outFile.Close();
        }
    }
}