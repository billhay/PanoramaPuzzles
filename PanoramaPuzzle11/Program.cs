namespace PanoramaPuzzle11
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        private const int PeopleCount = 5;

        private const int ItemCount = 5;

        static void Main(string[] args)
        {
            IRule rules = new Rules();
            Person[] all = Person.AllCombinations(rules.IsValid).ToArray();
            var outFile = Console.Out; // File.CreateText("GameResults.txt");
            {
                all
                    .AllCombinations()
                    .Where(IsValid)
                    .ForEach(p => p.ForEach(outFile.WriteLine, null, outFile.WriteLine));
            }

            outFile.Close();
        }

        // This filters out any putative solution where two people
        // share an attribute, like two people each with black shoes
        static bool IsValid(IEnumerable<Person> ip)
        {
            ISet<Person> people = ip.ToHashSet();

            // check we have unique combination of all attributes
            int count1 = people.Count;
            int count2 = people.Select(p => p.Name).ToHashSet().Count();
            int count3 = people.Select(p => p.Vegetable).ToHashSet().Count();
            int count4 = people.Select(p => p.Cheese).ToHashSet().Count();
            int count5 = people.Select(p => p.Meat).ToHashSet().Count();

            if (count1 == PeopleCount && count2 == PeopleCount && count3 == ItemCount && count4 == ItemCount &&
                count5 == ItemCount)
            {
                return true;
            }

            return false;
        }
    }
}