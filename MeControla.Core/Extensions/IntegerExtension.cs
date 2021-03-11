using System.Diagnostics;

namespace MeControla.Core.Extensions
{
    public static class IntegerExtension
    {
        [DebuggerStepThrough]
        public static string Pad(this int number, int length)
            => number.ToString($"D{length}");
    }
}