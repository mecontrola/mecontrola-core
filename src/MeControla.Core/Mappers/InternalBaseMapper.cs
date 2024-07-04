using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Mappers
{
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
    public abstract class InternalBaseMapper<TParam, TResult>
         where TResult : class
    {
        private readonly IMapper mapper;

        protected InternalBaseMapper()
            => mapper = new MapperConfiguration(cfg => CreateMap(cfg)).CreateMapper();

        protected IMappingExpression<TParam, TResult> CreateMap(IMapperConfigurationExpression cfg)
        {
            var map = cfg.CreateMap<TParam, TResult>();

            MapFields(map);

            return map;
        }

        protected virtual void MapFields(IMappingExpression<TParam, TResult> map)
        { }

        public TResult ToMap(TParam obj)
            => mapper.Map<TResult>(obj);

        public TResult ToMap(TParam obj, TResult result)
            => mapper.Map(obj, result);

        public IList<TResult> ToMapList<T>(T list)
            where T : IList<TParam>, ICollection<TParam>
            => list.Select(itm => ToMap(itm)).ToList();
    }
}