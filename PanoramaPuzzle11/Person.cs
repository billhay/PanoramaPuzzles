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
        public Names Name { get; set; }

        public Vegetable Vegetable { get; set; }

        public Cheese Cheese { get; set; }

        public Meat Meat { get; set; }

        public Gender Gender
        {
            get { return this.Name == Names.David || this.Name == Names.John ? Gender.Male : Gender.Female; }
        }

        public static IEnumerable<Person> AllCombinations(Func<Person, bool> isValid)
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


            T[] GetAllEnums<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Vegetable} {this.Cheese} {this.Meat}";
        }
    }
}