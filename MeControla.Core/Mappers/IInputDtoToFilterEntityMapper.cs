using MeControla.Core.Data.Dtos;
using MeControla.Core.Data.Entities;

namespace MeControla.Core.Mappers
{
    public interface IInputDtoToFilterEntityMapper<TParam, TResult> : IMapper<TParam, TResult>
        where TParam : class, IInputDto
        where TResult : class, IFilterEntity
    { }
}