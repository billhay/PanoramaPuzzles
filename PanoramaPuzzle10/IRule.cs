//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IRule.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the IRule.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace PanoramaPuzzle10
{
    public interface IRule
    {
        bool IsValid(Person person);
    }
}