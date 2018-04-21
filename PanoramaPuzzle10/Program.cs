namespace PanoramaPuzzle10
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            Rules rules = new Rules();
            Person[] pa1 = Person.GetAllCombinations().ToArray();

            List<Tuple<Person, Person, Person, Person>> validCombination = new List<Tuple<Person, Person, Person, Person>>();
            Person[] selected = pa1.Where(rules.IsValid).ToArray();
            //foreach(Person p1 in selected)
            //foreach(Person p2 in selected)
            //foreach(Person p3 in selected)
            //foreach(Person p4 in selected)
            for(int i = 0; i < selected.Length -3; i++)            
            for(int j = i; j < selected.Length -2; j++)
            for(int k = j; k < selected.Length -1; k++)
            for(int l = k; l < selected.Length; l++)

            {
                var p1 = selected[i];
                var p2 = selected[j];
                var p3 = selected[k];
                var p4 = selected[l];

                if (IsValid(p1, p2, p3, p4))
                {
                    validCombination.Add(new Tuple<Person, Person, Person, Person>(p1, p2, p3, p4));
                    Console.WriteLine(p1);
                    Console.WriteLine(p2);
                    Console.WriteLine(p3);
                    Console.WriteLine(p4);
                    Console.WriteLine();
                }
            }
        }

        static bool IsValid(Person p1, Person p2, Person p3, Person p4)
        {
            Person[] people = new Person[] { p1, p2, p3, p4 };
            HashSet<Person> persons = new HashSet<Person>(people);
            if (persons.Count != 4)
            {
                return false;
            }

            // first check we have unique combinatioin of all attributes
            HashSet<FirstName> firstNames = new HashSet<FirstName>();
            HashSet<LastName> lastNames = new HashSet<LastName>();
            HashSet<Jacket> jackets = new HashSet<Jacket>();
            HashSet<Shoes> shoes = new HashSet<Shoes>();

            foreach (Person p in people)
            {
                firstNames.Add(p.FirstName);
                lastNames.Add(p.LastName);
                jackets.Add(p.Jacket);
                shoes.Add(p.Shoes);
            }

            int firstNameCount = firstNames.Count;
            int lastNameCount = lastNames.Count;
            int jacketsCount = jackets.Count;
            int shoesCount = shoes.Count;

            return firstNameCount + lastNameCount + jacketsCount + shoesCount == 16;
        }
    }
}