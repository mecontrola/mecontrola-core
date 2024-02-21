using System;

namespace MeControla.Core.Mappers
{
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
    public abstract class BaseMapper<TParam, TResult> : InternalBaseMapper<TParam, TResult>, IMapper<TParam, TResult>
         where TParam : class
         where TResult : class
    { }

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
    public abstract class EnumBaseMapper<TParam, TResult> : InternalBaseMapper<TParam, TResult>, IEnumMapper<TParam, TResult>
         where TParam : Enum
         where TResult : class
    { }
}