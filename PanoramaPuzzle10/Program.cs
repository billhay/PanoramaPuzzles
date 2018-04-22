namespace PanoramaPuzzle10
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            IRule rules = new Rules();
            IEnumerable<Person> selected = Person.AllCombinations(rules.IsValid);
            selected
                .Combinations(4)
                .Where(IsValid)
                .SelectMany(s =>s)
                .ForEach(Console.WriteLine, null, Console.WriteLine);
        }

        // This filters out any putative solution where two people
        // share an attribute, like two people each with black shoes
        static bool IsValid(IEnumerable<Person> ip)
        {
            ISet<Person> people = ip.ToHashSet();

            // check we have unique combination of all attributes
            return people.Count == 4
                && people.Select(p => p.FirstName).ToHashSet().Count() == 4
                && people.Select(p => p.LastName).ToHashSet().Count() == 4
                && people.Select(p => p.Jacket).ToHashSet().Count() == 4
                && people.Select(p => p.Shoes).ToHashSet().Count() == 4;
        }
    }
}