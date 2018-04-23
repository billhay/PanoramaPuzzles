//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IRule.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the IRule.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace PanoramaPuzzleLib
{
    public interface IRule<T>
    {
        bool IsValid(T person);
    }
}