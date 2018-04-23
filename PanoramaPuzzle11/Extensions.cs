//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Extensions.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the Extensions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace PanoramaPuzzle11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            var el = elements.ToList();
            return k == 0 ? new[] { new T[0] } :
                el.SelectMany((e, i) =>
                    el.Skip(i + 1).Combinations(k - 1).Select(c => (new[] {e}).Concat(c)));
        }

        public static List<List<Person>> AllCombinations(this Person[] people)
        {
            List<List<Person>> allPossibilities = new List<List<Person>>();
            
            Dictionary<Names, List<Person>> partitions = new Dictionary<Names, List<Person>>();
            foreach (Person person in people)
            {
                if (!partitions.ContainsKey(person.Name))
                {
                    partitions[person.Name] = new List<Person>();
                }
                
                partitions[person.Name].Add(person);
            }

            Person[] david = people.Where(p => p.Name == Names.David).ToArray();
            Person[] john = people.Where(p => p.Name == Names.John).ToArray();
            Person[] doris = people.Where(p => p.Name == Names.Doris).ToArray();
            Person[] ruth = people.Where(p => p.Name == Names.Ruth).ToArray();
            Person[] betty = people.Where(p => p.Name == Names.Betty).ToArray();

            foreach (Person p1 in david)
            foreach (Person p2 in john)
            foreach (Person p3 in doris)
            foreach (Person p4 in ruth)
            foreach (Person p5 in betty)
            {
                allPossibilities.Add(MakeList(p1, p2, p3, p4, p5));
            }

            return allPossibilities;
        }

        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> action, Action prelude = null, Action postlude = null)
        {
            prelude?.Invoke();

            foreach (T element in elements)
            {
                action(element);
            }

            postlude?.Invoke();
        }

        public static List<Person> MakeList(params Person[] people)
        {
            return new List<Person>(people);
        }
    }
}