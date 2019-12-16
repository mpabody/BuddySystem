using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Services.Extensions
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Extension method that turns an IEnumerable of strings into a single string separated by spaces.
        /// </summary>
        /// <param name = "enumerable" > Given collection of strings that will be turned into a single continuous string.</param>
        /// <returns>A single string that holds all of the original string values.</returns>
        public static string ToSingleString(this IEnumerable<string> enumerable)
            {
                if (enumerable.Count() == 1)
                    return enumerable.ElementAt(0);

                var newString = "";

                foreach (var str in enumerable)
                {
                    newString += $"{str}{((str == enumerable.ElementAt(enumerable.Count() - 1)) ? "" : " ")}";
                }

                return newString;
            }
        
    }
}
