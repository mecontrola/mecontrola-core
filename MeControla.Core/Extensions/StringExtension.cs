using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MeControla.Core.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static Guid ToGuid(this string str)
            => Guid.Parse(str);

        [DebuggerStepThrough]
        public static DateTime ToDateTime(this string str)
            => DateTime.Parse(str);

        [DebuggerStepThrough]
        public static string ToPascalCase(this string value)
            => value.ToTitleCase().Replace(" ", string.Empty);

        [DebuggerStepThrough]
        public static string ToCamelCase(this string value)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new string(new CultureInfo("en-US", false).TextInfo
                                                             .ToTitleCase(string.Join(" ", pattern.Matches(value)).ToLower())
                                                             .Replace(@" ", string.Empty)
                                                             .Select((x, i) => i == 0 ? char.ToLower(x) : x)
                                                             .ToArray());
        }

        [DebuggerStepThrough]
        public static string ToSnakeCase(this string input)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("_", pattern.Matches(input)).ToLower();
        }

        [DebuggerStepThrough]
        public static string ToKebabCase(this string value)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("-", pattern.Matches(value)).ToLower();
        }

        [DebuggerStepThrough]
        public static string ToTitleCase(this string value)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new CultureInfo("en-US", false).TextInfo
                                                  .ToTitleCase(string.Join(" ", pattern.Matches(value)).ToLower());
        }

        [DebuggerStepThrough]
        public static string OnlyNumbers(this string value)
            => Regex.Replace(value, @"\D+", string.Empty);
    }
}