using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }
    }
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> DivideList<T>(this IEnumerable<T> array, int size)
        {
            return array.ToList().Select((s, i) => array.Skip(i * size).Take(size)).Where(a => a.Any());
        }
    }
    public static class IDictionaryExtensions
    {
        public static IEnumerable<IEnumerable<KeyValuePair<T,T>>> Divide<T>(this IDictionary<T,T> array, int size)
        {
            return array.ToList().Select((s, i) => array.Skip(i * size).Take(size)).Where(a => a.Any());
        }
    }
}
