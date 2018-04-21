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
            List<Person> selected = Person.GetAllCombinations(rules.IsValid).ToList();
            var all = selected.Combinations(4);
            foreach (var combination in all)
            {
                ISet<Person> people = combination.ToHashSet();
                if (IsValid(people))
                {
                    foreach (Person p in people)
                    {
                        Console.WriteLine(p);
                    }

                    Console.WriteLine();
                }
            }
        }


        // This filters out any putative solution where two people
        // share an attribute, like two people each with black shoes
        static bool IsValid(ISet<Person> people)
        {
            if (people.Count != 4)
            {
                return false;
            }

            // first check we have unique combination of all attributes
            int total = people.Select(p => p.FirstName).ToHashSet().Count();
            total += people.Select(p => p.LastName).ToHashSet().Count();
            total += people.Select(p => p.Jacket).ToHashSet().Count();
            total += people.Select(p => p.Shoes).ToHashSet().Count();

            return total == 16;
        }
    }
}