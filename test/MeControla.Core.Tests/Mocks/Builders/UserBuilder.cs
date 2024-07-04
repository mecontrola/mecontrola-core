using MeControla.Core.Builders;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using System;

namespace MeControla.Core.Tests.Mocks.Builders
{
    public class UserBuilder : BaseBuilder<UserBuilder, User>, IBuilder<User>
    {
        protected override void FillDefaultValues(User obj)
            => obj.Uuid = Guid.NewGuid();

        public UserBuilder SetName(string value)
            => Set(obj => obj.Name = value);
    }
}