using MeControla.Core.Data.Dtos;
using System;

namespace MeControla.Core.Tests.Mocks.Datas.Dtos
{
    public class UserDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}