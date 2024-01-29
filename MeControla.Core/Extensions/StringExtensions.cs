using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MeControla.Core.Extensions
{
    public static partial class StringExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static bool IsNullOrEmpty(this string str)
            => string.IsNullOrEmpty(str);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static bool IsNullOrWhiteSpace(this string str)
            => string.IsNullOrWhiteSpace(str);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static Guid ToGuid(this string str)
            => Guid.Parse(str);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static DateTime ToDateTime(this string str)
            => DateTime.Parse(str);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToPascalCase(this string value)
            => value.ToTitleCase().Replace(" ", string.Empty);

        [GeneratedRegex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+")]
        private static partial Regex RegexCamelCase();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToCamelCase(this string value)
        {
            var pattern = RegexCamelCase();
            return new string(new CultureInfo("en-US", false).TextInfo
                                                             .ToTitleCase(string.Join(" ", pattern.Matches(value)).ToLowerInvariant())
                                                             .Replace(@" ", string.Empty)
                                                             .Select((x, i) => i == 0 ? char.ToLower(x) : x)
                                                             .ToArray());
        }

        [GeneratedRegex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+")]
        private static partial Regex RegexSnakeKebabTitleCase();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToSnakeCase(this string input)
            => string.Join("_", RegexSnakeKebabTitleCase().Matches(input))
                     .ToLowerInvariant();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToKebabCase(this string value)
            => string.Join("-", RegexSnakeKebabTitleCase().Matches(value))
                     .ToLowerInvariant();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToTitleCase(this string value)
            => new CultureInfo("en-US", false).TextInfo
                                              .ToTitleCase(string.Join(" ", RegexSnakeKebabTitleCase().Matches(value))
                                                                 .ToLowerInvariant());

        [GeneratedRegex(@"\D+")]
        private static partial Regex RegexOnlyNumbers();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string OnlyNumbers(this string value)
            => RegexOnlyNumbers().Replace(value, string.Empty);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string Base64Encode(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string Base64Decode(this string value)
        {
            var bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }

        [GeneratedRegex(@"\s+")]
        private static partial Regex RegexTrimAll();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string TrimAll(this string value)
            => RegexTrimAll().Replace(value, " ").Trim();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToMD5(this string input)
        {
            var data = MD5.HashData(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();

            for (int i = 0, l = data.Length; i < l; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static DateTime? ToNullableDateTime(this string value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        [GeneratedRegex(@"[^\d|.]")]
        private static partial Regex RegexToDecimal();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static decimal? ToDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var str = value.Replace(",", ".");
            str = RegexToDecimal().Replace(str, string.Empty);

            try
            {
                return decimal.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToFirstUpper(this string value)
            => string.IsNullOrWhiteSpace(value)
             ? string.Empty
             : $"{value[0].ToString().ToUpper()}{value[1..]}";

        [GeneratedRegex("[aeiou]", RegexOptions.IgnoreCase)]
        private static partial Regex RegexGetConsonants();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string GetConsonants(this string value)
            => RegexGetConsonants().Replace(value, string.Empty);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string GetUpperLetters(this string value)
            => string.Concat(value.Where(c => c >= 'A' && c <= 'Z'));
    }
}