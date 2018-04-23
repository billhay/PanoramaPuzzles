//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Extensions.cs" company="BillCo">
//  (c) William D Hay 2017
//  </copyright>
//  <summary>
//  Defines the Extensions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace PanoramaPuzzleLib
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static IReadOnlyCollection<IReadOnlyCollection<T>> AllCombinations<T>(this IEnumerable<T> people, Func<T, object> getPartionKey)
        {
            Dictionary<object, List<T>> partitions = new Dictionary<object, List<T>>();
            foreach (T person in people)
            {
                object key = getPartionKey(person);
                if (!partitions.ContainsKey(key))
                {
                    partitions[key] = new List<T>();
                }
                
                partitions[key].Add(person);
            }

            return partitions.CombineLists();
        }

        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> action, Action prelude = null, Action postlude = null)
        {
            prelude?.Invoke();

            foreach (T element in elements)
            {
                action(element);
            }

            postlude?.Invoke();
        }

        public static IReadOnlyCollection<IReadOnlyCollection<T>> CombineLists<TX, T>(this Dictionary<TX, List<T>> dictionary)
        {
            return dictionary.Values.CombineLists();
        }

        public static IReadOnlyCollection<IReadOnlyCollection<T>> CombineLists<T>(this IReadOnlyCollection<IReadOnlyCollection<T>> lists)
        {
            List<List<T>> start = new List<List<T>>() { new List<T>() };
            foreach (var list in lists)
            {
                start = AddList(start, list);
            }

            return start;

            List<List<T>> AddList(IReadOnlyCollection<IReadOnlyCollection<T>> root, IReadOnlyCollection<T> stringList)
            {
                List<List<T>> newListOfLists = new List<List<T>>();
                ;
                foreach (var list in root)
                {
                    foreach (var item in stringList)
                    {
                        newListOfLists.Add(new List<T>(list) { item });
                    }
                }

                return newListOfLists;
            }
        }
    }
}