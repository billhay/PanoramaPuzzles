//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Person.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the Person.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------
namespace PanoramaPuzzle11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PanoramaPuzzleLib;

    public class Person
    {
        private const int PeopleCount = 5;

        private const int ItemCount = 5;

        internal Names Name { get; set; }

        internal Vegetable Vegetable { get; set; }

        internal Cheese Cheese { get; set; }

        internal Meat Meat { get; set; }

        internal Gender Gender
        {
            get { return this.Name == Names.David || this.Name == Names.John ? Gender.Male : Gender.Female; }
        }

        internal static IEnumerable<Person> AllCombinations(Func<Person, bool> isValid)
        {
            return
                Helper.GetAllEnums<Names>().Select(n =>
                        Helper.GetAllEnums<Vegetable>().Select(v =>
                            Helper.GetAllEnums<Cheese>().Select(c =>
                                Helper.GetAllEnums<Meat>().Select(m =>
                                    new Person { Name = n, Vegetable = v, Cheese = c, Meat = m }))))
                    .SelectMany(x => x)
                    .SelectMany(s => s)
                    .SelectMany(s => s)
                    .Where(isValid);
        }

        // This filters out any putative solution where two people
        // share an attribute, like two people each with black shoes
        internal static bool IsValid(IEnumerable<Person> ip)
        {
            ISet<Person> people = ip.ToHashSet();

            // check we have unique combination of all attributes

            HashSet<Names> nameSet = new HashSet<Names>();
            HashSet<Vegetable> vegatableSet = new HashSet<Vegetable>();
            HashSet<Cheese> cheeseSet = new HashSet<Cheese>();
            HashSet<Meat> meatSet = new HashSet<Meat>();
            foreach (Person p in ip)
            {
                nameSet.Add(p.Name);
                vegatableSet.Add(p.Vegetable);
                cheeseSet.Add(p.Cheese);
                meatSet.Add(p.Meat);
            }
            return
                nameSet.Count() == PeopleCount
                && vegatableSet.Count() == ItemCount
                && cheeseSet.Count() == ItemCount
                && meatSet.Count() == ItemCount;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Vegetable} {this.Cheese} {this.Meat}";
        }
    }
}