using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MeControla.Core.Extensions
{
    public static class StringExtensions
    {
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

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToCamelCase(this string value)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new string(new CultureInfo("en-US", false).TextInfo
                                                             .ToTitleCase(string.Join(" ", pattern.Matches(value)).ToLower())
                                                             .Replace(@" ", string.Empty)
                                                             .Select((x, i) => i == 0 ? char.ToLower(x) : x)
                                                             .ToArray());
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToSnakeCase(this string input)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("_", pattern.Matches(input)).ToLower();
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToKebabCase(this string value)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("-", pattern.Matches(value)).ToLower();
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToTitleCase(this string value)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new CultureInfo("en-US", false).TextInfo
                                                  .ToTitleCase(string.Join(" ", pattern.Matches(value)).ToLower());
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string OnlyNumbers(this string value)
            => Regex.Replace(value, @"\D+", string.Empty);

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
            => Regex.Replace(value, @"\s+", " ").Trim();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string ToMD5(this string input)
        {
            using var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
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
            catch(FormatException)
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
            str = Regex.Replace(str, @"[^\d|.]", string.Empty);

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
    }
}