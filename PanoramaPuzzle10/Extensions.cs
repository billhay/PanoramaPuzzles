﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Extensions.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the Extensions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace PanoramaPuzzle10
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            var el = elements.ToList();
            return k == 0 ? new[] { new T[0] } :
                el.SelectMany((e, i) =>
                    el.Skip(i + 1).Combinations(k - 1).Select(c => (new[] {e}).Concat(c)));
        }
    }
}