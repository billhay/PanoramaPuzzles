using System;
using System.Collections.Generic;
using System.Text;

namespace PanoramaPuzzleLib
{
    using System.Linq;

    public static class Helper
    {
        public static IReadOnlyCollection<T> GetAllEnums<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
