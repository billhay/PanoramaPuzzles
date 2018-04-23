//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Person.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the Person.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------
namespace PanoramaPuzzle10
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PanoramaPuzzleLib;

    public class Person
    {
        public FirstName FirstName { get; set; }

        public Jacket Jacket { get; set; }

        public LastName LastName { get; set; }

        public Shoes Shoes { get; set; }

        public static IEnumerable<Person> AllCombinations(Func<Person, bool> isValid)
        {
            return
                Helper.GetAllEnums<FirstName>().Select(f =>
                        Helper.GetAllEnums<LastName>().Select(l =>
                            Helper.GetAllEnums<Shoes>().Select(s =>
                                Helper.GetAllEnums<Jacket>().Select(j =>
                                    new Person { FirstName = f, LastName = l, Shoes = s, Jacket = j }))))
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
            return people.Count == 4
                   && people.Select(p => p.FirstName).ToHashSet().Count() == 4
                   && people.Select(p => p.LastName).ToHashSet().Count() == 4
                   && people.Select(p => p.Jacket).ToHashSet().Count() == 4
                   && people.Select(p => p.Shoes).ToHashSet().Count() == 4;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Shoes} {this.Jacket}";
        }
    }
}