using FluentAssertions;
using MeControla.Core.Configurations.Extensions;
using MeControla.Core.IoC;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace MeControla.Core.Tests.Configurations.Extensions
{
    public class SetUpExtensionTests
    {
        private static readonly string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        private readonly FileInfo assemblyFileInfo = new($"{assemblyName}.dll");

        protected readonly IServiceCollection serviceCollection;

        public SetUpExtensionTests()
            => serviceCollection = new ServiceCollection();

        [Fact(DisplayName = "[SetUpExtension.AddApplicationServices] Deve retornar null quando não existir atributo customizado.")]
        public void DeveRetornarNullQuandoAtributoInexistente2()
        {
            serviceCollection.AddApplicationServices();

            serviceCollection.Should().HaveCount(1);
        }

        [Fact(DisplayName = "[SetUpExtension.GetAssembly] Deve retornar null quando gera a exceção ArgumentException.")]
        public void DeveRetornarNullQuandoExcecaoArgumentException()
        {
            var currentAppDomain = Substitute.For<INetCoreAppDomain>();
            currentAppDomain.Load(Arg.Any<AssemblyName>()).Throws(new ArgumentException());

            var actual = SetUpExtension.GetAssembly(assemblyFileInfo, currentAppDomain);
            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[SetUpExtension.GetAssembly] Deve retornar null quando gera a exceção FileNotFoundException.")]
        public void DeveRetornarNullQuandoExcecaoFileNotFoundException()
        {
            var currentAppDomain = Substitute.For<INetCoreAppDomain>();
            currentAppDomain.Load(Arg.Any<AssemblyName>()).Throws(new FileNotFoundException());

            var actual = SetUpExtension.GetAssembly(assemblyFileInfo, currentAppDomain);
            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[SetUpExtension.GetAssembly] Deve retornar null quando gera a exceção BadImageFormatException.")]
        public void DeveRetornarNullQuandoExcecaoBadImageFormatException()
        {
            var currentAppDomain = Substitute.For<INetCoreAppDomain>();
            currentAppDomain.Load(Arg.Any<AssemblyName>()).Throws(new BadImageFormatException());

            var actual = SetUpExtension.GetAssembly(assemblyFileInfo, currentAppDomain);
            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[SetUpExtension.GetAssembly] Deve retornar null quando gera a exceção AppDomainUnloadedException.")]
        public void DeveRetornarNullQuandoExcecaoAppDomainUnloadedException()
        {
            var currentAppDomain = Substitute.For<INetCoreAppDomain>();
            currentAppDomain.Load(Arg.Any<AssemblyName>()).Throws(new AppDomainUnloadedException());

            var actual = SetUpExtension.GetAssembly(assemblyFileInfo, currentAppDomain);
            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[SetUpExtension.GetAssembly] Deve retornar null quando gera a exceção FileLoadException.")]
        public void DeveRetornarNullQuandoExcecaoFileLoadException()
        {
            var currentAppDomain = Substitute.For<INetCoreAppDomain>();
            currentAppDomain.Load(Arg.Any<AssemblyName>()).Throws(new FileLoadException());

            var actual = SetUpExtension.GetAssembly(assemblyFileInfo, currentAppDomain);
            actual.Should().BeNull();
        }
    }

    public class InjectorTest : IInjector
    {
        public void RegisterServices(IServiceCollection services)
            => services.AddSingleton<ClassTest>();
    }
}