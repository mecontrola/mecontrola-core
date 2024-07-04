using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace MeControla.Core.Tests.Mocks.Datas.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public IList<UserPermission> UserPermissions { get; set; }
    }
}