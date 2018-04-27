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

        private const ulong One = 1ul;

        public Person(Name name, Vegetable vegetable, Cheese cheese, Meat meat)
        {
            this.Name = name;
            this.Vegetable = vegetable;
            this.Cheese = cheese;
            this.Meat = meat;

            this.Gender = this.Name == Name.David || this.Name == Name.John ? Gender.Male : Gender.Female;

            this.ThumbPrint = 
                One << (int) this.Name + 48
              | One << (int) this.Vegetable + 32
              | One << (int) this.Cheese + 16
              | One << (int) this.Meat;
        }

        private const int ItemCount = 5;

        public Name Name { get; }

        public Vegetable Vegetable { get; }

        public Cheese Cheese { get; }

        public Meat Meat { get; }

        public ulong ThumbPrint { get; }

        public Gender Gender { get; }

        public static IEnumerable<Person> AllCombinations(Func<Person, bool> isValid)
        {
            return
                Helper.GetAllEnums<Name>().Select(n =>
                        Helper.GetAllEnums<Vegetable>().Select(v =>
                            Helper.GetAllEnums<Cheese>().Select(c =>
                                Helper.GetAllEnums<Meat>().Select(m =>
                                    new Person (n, v,  c,  m )))))
                    .SelectMany(x => x)
                    .SelectMany(s => s)
                    .SelectMany(s => s)
                    .Where(isValid);
        }

        // This filters out any putative solution where two people
        // share an attribute, like two people each with black shoes
        public static bool IsValid(IEnumerable<Person> ip)
        {
            return ip.ToList().AreElementsUnique(Distinct);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Vegetable} {this.Cheese} {this.Meat}";
        }

        public static bool Distinct(Person p1, Person p2)
        {
            ulong temp = p1.ThumbPrint & p2.ThumbPrint;
            return temp == 0;
        }
    }
}