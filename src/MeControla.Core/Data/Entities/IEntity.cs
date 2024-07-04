using System;

namespace MeControla.Core.Data.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        Guid Uuid { get; set; }
    }
}