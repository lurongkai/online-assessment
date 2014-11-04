using System;
using System.Collections.Generic;
using System.Linq;

namespace Oas.Domain.Service
{
    internal static class EnumerableExtension
    {
        internal static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count) {
            var list = source.ToList();
            var random = new Random();

            var result = new List<T>();
            for (int i = 0; i < count; i++) {
                var location = random.Next(0, list.Count - i);
                var node = list[location];
                result.Add(node);
                list.Remove(node);
                list.Add(node);
            }

            return result;
        }
    }
}