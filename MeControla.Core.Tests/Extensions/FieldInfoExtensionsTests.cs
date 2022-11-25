using System;
using System.Reflection;

namespace MeControla.Core.Tests.Extensions
{
    public static class FieldInfoExtensionsTests
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static T GetCustomAttribute<T>(this FieldInfo fieldInfo)
            where T : Attribute
            => (T)fieldInfo.GetCustomAttribute(typeof(T));
    }
}