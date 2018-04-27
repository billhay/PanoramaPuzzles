//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Rules.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the Rules.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------
namespace PanoramaPuzzle11
{
    using System;
    using System.Linq;

    internal static class Rules 
    {
        private static readonly Func<Person, bool>[] PuzzleRules = 
        {
            // rule 1
            p => p.Name != Name.John && p.Vegetable == Vegetable.Brocolli,
            p => p.Name == Name.John && p.Cheese == Cheese.Havarti,

            // rule 2
            p => p.Gender == Gender.Male && p.Vegetable == Vegetable.Carrots,
            p => p.Gender == Gender.Male && p.Cheese == Cheese.Swiss,
            p => p.Gender == Gender.Male && p.Meat == Meat.Chicken,
            p => p.Vegetable == Vegetable.Carrots && p.Cheese == Cheese.Swiss,
            p => p.Vegetable == Vegetable.Carrots && p.Meat == Meat.Chicken,
            p => p.Cheese == Cheese.Swiss && p.Meat == Meat.Chicken,

            // rule 3
            p => p.Gender == Gender.Male && p.Vegetable == Vegetable.Avocados,
            p => p.Gender == Gender.Male && p.Meat == Meat.BeefRoast,
            p => p.Vegetable == Vegetable.Avocados  && p.Meat != Meat.BeefRoast,

            // rule 4
            p => p.Meat == Meat.PorkRoast && p.Vegetable == Vegetable.Lettuce,
            p => p.Meat == Meat.PorkRoast && p.Cheese == Cheese.Gouda,

            // rule 5
            p => p.Gender == Gender.Male && p.Cheese == Cheese.Gorgonzola,
            p => p.Name == Name.Doris && p.Cheese == Cheese.Gorgonzola,

            // rule 6
            p => p.Name == Name.Ruth && p.Meat == Meat.GroundBeef,
            p => p.Meat == Meat.GroundBeef && p.Cheese == Cheese.Gouda,
            p => p.Gender == Gender.Male && p.Meat == Meat.GroundBeef,

            // rule 7
            p => p.Name == Name.Betty && p.Vegetable != Vegetable.Cucumber
        };


        internal static bool Valid(Person p, int ruleNumber)
        {
            bool b = PuzzleRules[ruleNumber](p);
            return b;
        }
        // for convenience the rules are backwards
        // if any of the attributes for a person succeeds
        // then that combination is invalid. For example a
        // a combination which had first name 'Clark' and 
        // shoes 'White' will cause this funtion to return 'false'
        internal static bool IsValid(Person person)
        {
            return !PuzzleRules.Any(rule => rule(person));
        }
    }
}