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
                GetAllEnums<Names>().Select(n =>
                        GetAllEnums<Vegetable>().Select(v =>
                            GetAllEnums<Cheese>().Select(c =>
                                GetAllEnums<Meat>().Select(m =>
                                    new Person { Name = n, Vegetable = v, Cheese = c, Meat = m }))))
                    .SelectMany(x => x)
                    .SelectMany(s => s)
                    .SelectMany(s => s)
                    .Where(isValid);


            IReadOnlyCollection<T> GetAllEnums<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>().ToList();
            }
        }

        // This filters out any putative solution where two people
        // share an attribute, like two people each with black shoes
        internal static bool IsValid(IEnumerable<Person> ip)
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

        public override string ToString()
        {
            return $"{this.Name} {this.Vegetable} {this.Cheese} {this.Meat}";
        }
    }
}