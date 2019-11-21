using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyruzAPIDemo
{
    public static class HelperExtensions
    {
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list != null && list.Any();
        }
        public static string Clean(this string text)
        {
            return text?.Trim()?.ToLowerInvariant();
        }
    }
}