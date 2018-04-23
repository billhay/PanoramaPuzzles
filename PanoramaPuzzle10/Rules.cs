//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Rules.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the Rules.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace PanoramaPuzzle10
{
    using System;
    using System.Linq;

    public class Rules
    {
        private static readonly Func<Person, bool>[] PuzzleRules = 
        {
            // rule 1
            (p => (p.FirstName == FirstName.Amanda && p.Jacket == Jacket.Red)),
            (p => (p.FirstName == FirstName.Amanda && p.Shoes == Shoes.Brown)),
            (p => (p.FirstName == FirstName.Amanda && p.LastName == LastName.Meyer)),
            (p => (p.Jacket == Jacket.Red && p.Shoes == Shoes.Brown)),
            (p => (p.LastName == LastName.Meyer && p.Shoes == Shoes.Brown)),
            (p => (p.LastName == LastName.Meyer && p.Jacket == Jacket.Red)),

            // rule 2
            (p => (p.LastName == LastName.Clark && p.Shoes == Shoes.White)),
            (p => (p.LastName == LastName.Clark && p.FirstName == FirstName.Carol)),

            // rule 3
            (p => (p.Shoes == Shoes.Tan && p.Jacket == Jacket.Red)),
            (p => (p.Shoes == Shoes.Tan && p.Jacket == Jacket.Blue)),

            // rule 4
            (p => (p.Jacket == Jacket.Yellow && p.Shoes == Shoes.Brown)),
            (p => (p.Jacket == Jacket.Yellow && p.FirstName == FirstName.Amanda)),

            // rule 5
            (p => (p.Jacket == Jacket.Blue && p.Shoes == Shoes.Black)),
            (p => (p.Jacket == Jacket.Blue && p.LastName == LastName.Johnson)),
            (p => (p.Shoes == Shoes.Black && p.LastName == LastName.Johnson)),  // missed this on first attempt

            // rule 6
            (p => (p.FirstName == FirstName.Amanda && p.Shoes == Shoes.Black)),
            (p => (p.FirstName == FirstName.Amanda && p.Jacket == Jacket.Green)),
            (p => (p.FirstName == FirstName.Belinda && p.Jacket == Jacket.Green)),
            (p => (p.FirstName == FirstName.Belinda && p.Shoes == Shoes.Black)),
        };

        // for convenience the PuzzleRules are backwards
        // if any of the attributes for a person succeeds
        // then that combination is invalid. For example a
        // a combination which had first name 'Clark' and 
        // shoes 'White' will cause this funtion to return 'false'
        public static bool IsValid(Person person)
        {
            return !PuzzleRules.Any(rule => rule(person));
        }
    }
}