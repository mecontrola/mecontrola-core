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
        private static readonly TimeSpan REGEX_TIMEOUT = TimeSpan.FromSeconds(2);

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
            => DateTime.Parse(str, CultureInfo.CurrentCulture);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToPascalCase(this string value)
            => value.ToTitleCase().Replace(" ", string.Empty);

        private const string PATTERN_CAMEL_CASE = @"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+";
        private static Regex RegexCamelCase()
            => new(PATTERN_CAMEL_CASE, RegexOptions.None, REGEX_TIMEOUT);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToCamelCase(this string value)
            => new(new CultureInfo("en-US", false).TextInfo
                                                  .ToTitleCase(string.Join(" ", RegexCamelCase().Matches(value)).ToLowerInvariant())
                                                  .Replace(@" ", string.Empty)
                                                  .Select((x, i) => i == 0 ? char.ToLower(x) : x)
                                                  .ToArray());

        private const string PATTERN_SNAKE_KEBAB_TITLE_CASE = @"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+";

        private static Regex RegexSnakeKebabTitleCase()
            => new(PATTERN_SNAKE_KEBAB_TITLE_CASE, RegexOptions.None, REGEX_TIMEOUT);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToSnakeCase(this string value)
        {
            var matches = RegexSnakeKebabTitleCase().Matches(value);
            return string.Join("_", matches)
                         .ToLowerInvariant();
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToKebabCase(this string value)
        {
            var matches = RegexSnakeKebabTitleCase().Matches(value);
            return string.Join("-", matches)
                         .ToLowerInvariant();
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToTitleCase(this string value)
        {
            var matches = RegexSnakeKebabTitleCase().Matches(value);
            return new CultureInfo("en-US", false).TextInfo
                                                  .ToTitleCase(string.Join(" ", matches)
                                                                     .ToLowerInvariant());
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string OnlyNumbers(this string value)
            => Regex.Replace(value, @"\D+", string.Empty, RegexOptions.None, REGEX_TIMEOUT);

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

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string TrimAll(this string value)
            => Regex.Replace(value, @"\s+", " ", RegexOptions.None, REGEX_TIMEOUT).Trim();

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

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static decimal? ToDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var str = value.Replace(",", ".");
            str = Regex.Replace(str, @"[^\d|.]", string.Empty, RegexOptions.None, REGEX_TIMEOUT);

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

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string GetConsonants(this string value)
            => Regex.Replace(value, "[aeiou]", string.Empty, RegexOptions.IgnoreCase, REGEX_TIMEOUT);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string GetUpperLetters(this string value)
            => string.Concat(value.Where(c => c >= 'A' && c <= 'Z'));
    }
}