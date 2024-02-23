using AutoMapper;
using MeControla.Core.Data.Enums;
using MeControla.Core.Extensions;
using System;

namespace MeControla.Core.Mappers
{
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
    public abstract class BaseEnumToDtoMapper<TParam, TResult> : InternalBaseMapper<TParam, TResult>, IEnumToDtoMapper<TParam, TResult>
         where TParam : struct, Enum
         where TResult : BaseEnumItemDto, new()
    {
        protected override void MapFields(IMappingExpression<TParam, TResult> map)
            => map.ConvertUsing((source, destionation) =>
            {
                if (!Enum.IsDefined(typeof(TParam), source))
                    return null;

                destionation ??= new TResult();
                destionation.Id = Convert.ToUInt32(source);
                destionation.Value = source.GetDescription();

                return destionation;
            });
    }
}