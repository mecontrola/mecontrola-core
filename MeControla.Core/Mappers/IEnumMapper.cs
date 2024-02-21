using System;
using System.Collections.Generic;

namespace MeControla.Core.Mappers
{
    public interface IEnumMapper<TParam, TResult>
        where TParam : Enum
        where TResult : class
    {
        TResult ToMap(TParam obj);
        TResult ToMap(TParam obj, TResult result);
        IList<TResult> ToMapList<T>(T list)
            where T : IList<TParam>, ICollection<TParam>;
    }
}