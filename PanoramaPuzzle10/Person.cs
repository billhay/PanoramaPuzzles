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

    public class Person
    {
        public FirstName FirstName { get; set; }

        public Jacket Jacket { get; set; }

        public LastName LastName { get; set; }

        public Shoes Shoes { get; set; }

        public static IEnumerable<Person> AllCombinations(Func<Person, bool> isValid)
        {
            return
                GetAllEnums<FirstName>().Select(f =>
                        GetAllEnums<LastName>().Select(l =>
                            GetAllEnums<Shoes>().Select(s =>
                                GetAllEnums<Jacket>().Select(j =>
                                    new Person { FirstName = f, LastName = l, Shoes = s, Jacket = j }))))
                    .SelectMany(x => x)
                    .SelectMany(s => s)
                    .SelectMany(s => s)
                    .Where(isValid);


            T[] GetAllEnums<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Shoes} {this.Jacket}";
        }
    }
}