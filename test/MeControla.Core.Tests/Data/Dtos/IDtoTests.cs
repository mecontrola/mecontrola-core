using MeControla.Core.Data.Dtos;
using System;
using System.Reflection;
using Xunit;

namespace MeControla.Core.Tests.Data.Dtos;

public class IDtoTests
{
    [Fact(DisplayName = "[IDto] Deve verificar os métodos da base para os DTOs.")]
    public void DeveVerificarMetodosDTO()
    {
        var expected = Guid.NewGuid();
        var test = new Tests { Id = expected };
        var methodInfos = typeof(Tests).GetMethods(BindingFlags.Public | BindingFlags.Instance);

        Assert.Equal(6, methodInfos.Length);
        Assert.Equal("get_Id", methodInfos[0].Name);
        Assert.Equal("set_Id", methodInfos[1].Name);
        Assert.Equal(expected, test.Id);
    }

    internal class Tests : IDto
    {
        public Guid Id { get; set; }
    }
}