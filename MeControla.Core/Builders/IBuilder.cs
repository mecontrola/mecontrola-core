using MeControla.Core.Data.Entities;

namespace MeControla.Core.Builders
{
    public interface IBuilder<TObject>
        where TObject : IEntity
    {
        TObject ToBuild();
    }
}