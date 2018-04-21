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

            for(int i = 0; i < selected.Count -3; i++)            
            for(int j = i + 1; j < selected.Count -2; j++)
            for(int k = j + 1; k < selected.Count -1; k++)
            for(int l = k + 1; l < selected.Count; l++)
            {
                List<Person> people = new List<Person>(new[] { selected[i], selected[j], selected[k], selected[l] });

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
        static bool IsValid(IList<Person> people)
        {
            HashSet<Person> persons = new HashSet<Person>(people);
            if (persons.Count != 4)
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