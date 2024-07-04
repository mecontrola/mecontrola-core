using MeControla.Core.Data.Enums;
using System;
using System.Collections.Generic;

namespace MeControla.Core.Mappers
{
    public interface IEnumToDtoMapper<TParam, TResult>
        where TParam : Enum
        where TResult : IEnumDto
    {
        TResult ToMap(TParam obj);
        TResult ToMap(TParam obj, TResult result);
        IList<TResult> ToMapList<T>(T list)
            where T : IList<TParam>, ICollection<TParam>;
    }
}