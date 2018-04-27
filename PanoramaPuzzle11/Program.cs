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
            Person p1 = new Person(Name.David, Vegetable.Lettuce, Cheese.Gouda, Meat.LegOfLamb);
            Person p2 = new Person(Name.John, Vegetable.Brocolli, Cheese.Brie, Meat.PorkRoast);
            Person p3 = new Person(Name.Ruth, Vegetable.Avocados, Cheese.Swiss, Meat.BeefRoast);
            Person p4 = new Person(Name.Betty, Vegetable.Cucumber, Cheese.Gorgonzola, Meat.Chicken);
            Person p5 = new Person(Name.Doris, Vegetable.Carrots, Cheese.Havarti, Meat.GroundBeef);

            List<Person> candidate = new List<Person> { p1, p2, p3, p4, p5 };
            bool unique = candidate.AreElementsUnique(Test);

            IEnumerable<Person> all = Person.AllCombinations(Rules.IsValid);
            var outFile = Console.Out; // File.CreateText("GameResults.txt");

            all
                .AllCombinations(getPartionKey: x => x.Name)
                .Where(Person.IsValid)
                .ForEach(p => p.ForEach(outFile.WriteLine, null, outFile.WriteLine));

            outFile.Close();
        }

        static bool Test(Person p1, Person p2)
        {
            ulong foo = p1.ThumbPrint & p2.ThumbPrint;
            return foo == 0;
        }
    }
}