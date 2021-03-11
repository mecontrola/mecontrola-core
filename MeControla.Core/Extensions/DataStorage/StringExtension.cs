using System.Diagnostics;

namespace MeControla.Core.Extensions.DataStorage
{
    public static class StringExtension
    {
        [DebuggerStepThrough]
        public static string GetColumnName(this string str, string prefix)
            => $"{prefix}_{str.ToSnakeCase()}";
    }
}