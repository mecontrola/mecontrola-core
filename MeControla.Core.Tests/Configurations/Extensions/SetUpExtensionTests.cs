using FluentAssertions;
using MeControla.Core.Configurations.Extensions;
using MeControla.Core.IoC;
using MeControla.Core.Tests.Datas.Mocks.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.Core.Tests.Configurations.Extensions
{
    public class SetUpExtensionTests
    {
        protected readonly IServiceCollection serviceCollection;

        public SetUpExtensionTests()
        {
            serviceCollection = new ServiceCollection();
        }

        [Fact(DisplayName = "[SetUpExtension.AddApplicationServices] Deve retornar null quando não existir atributo customizado.")]
        public void DeveRetornarNullQuandoAtributoInexistente2()
        {
            var injectorTest = typeof(InjectorTest);

            serviceCollection.AddApplicationServices();

            serviceCollection.Should().HaveCount(1);
        }
    }


    public class InjectorTest : IInjector
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ClassTest>();
        }
    }
}