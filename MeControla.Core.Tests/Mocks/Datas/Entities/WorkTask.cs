using MeControla.Core.Data.Entities;
using System;

namespace MeControla.Core.Tests.Mocks.Datas.Entities
{
    public class WorkTask : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Description { get; set; }
    }
}