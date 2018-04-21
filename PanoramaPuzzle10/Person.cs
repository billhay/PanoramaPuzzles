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

    public class Person
    {
        public FirstName FirstName { get; set; }

        public Jacket Jacket { get; set; }

        public LastName LastName { get; set; }

        public Shoes Shoes { get; set; }

        public static IEnumerable<Person> GetAllCombinations()
        {
            foreach (FirstName firstName in Enum.GetValues(typeof(FirstName)))
            foreach (LastName lastName in Enum.GetValues(typeof(LastName)))
            foreach (Jacket jacket in Enum.GetValues(typeof(Jacket)))
            foreach (Shoes shoes in Enum.GetValues(typeof(Shoes)))
            {
                yield return new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Jacket = jacket,
                    Shoes = shoes
                };
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Shoes} {this.Jacket}";
        }
    }
}