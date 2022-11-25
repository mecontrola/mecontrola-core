namespace MeControla.Core.Extensions
{
    public static class IntegerExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static string Pad(this int number, int length)
            => number.ToString($"D{length}");
    }
}