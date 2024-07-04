using MeControla.Core.Data.Dtos;
using MeControla.Core.Data.Entities;

namespace MeControla.Core.Mappers
{
    public interface IDtoToEntityMapper<TParam, TResult> : IMapper<TParam, TResult>
        where TParam : class, IDto
        where TResult : class, IEntity
    { }
}