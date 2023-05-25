using System.Linq;

namespace MeControla.Core.Extensions.DataStorage
{
    public static class StringExtension
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string GetColumnName(this string value, string prefix)
            => $"{prefix}_{value.ToSnakeCase()}";

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string GetPrefixTable(this string value)
        {
            var valueTmp = value.ToTitleCase().TrimAll();
            var words = valueTmp.Split(" ");
            var prefix = string.Empty;

            prefix = words.Length > 1
                   ? string.Concat(words.Select(x => x[0])).ToLower()
                   : $"{valueTmp[0]}{valueTmp[1..].GetConsonants()}"[..2];

            return prefix.ToLower();
        }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string GetPrefixColumn(this string value)
        {
            var valueTmp = value.ToTitleCase().TrimAll();
            var words = valueTmp.Split(" ");
            var prefix = string.Empty;

            prefix = words.Length switch
            {
                >= 3 => valueTmp.GetUpperLetters(),
                2 => string.Concat(words.Select(x => x[..1] + x[1..].GetConsonants()[..1])),
                _ => $"{valueTmp[0]}{CheckSingleWord(valueTmp)}"[..3],
            };

            return prefix.ToLower();

            static string CheckSingleWord(string word)
            {
                var prefix = word[1..].GetConsonants();
                return prefix.Length == 1 ? $"{prefix}{word[^1]}" : prefix;
            }
        }
    }
}