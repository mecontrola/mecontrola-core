using FluentAssertions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Primitives;
using MeControla.Core.Tools;
using NSubstitute;
using System.Reflection;
using Xunit;

namespace MeControla.Core.Tests.Tools
{
    public class AssemblyInfoTests
    {
        private readonly AssemblyInfo assemblyInfoEmpty;
        private readonly AssemblyInfo assemblyInfoFill;

        public AssemblyInfoTests()
        {
            assemblyInfoEmpty = new AssemblyInfo(CreateEmpty());
            assemblyInfoFill = new AssemblyInfo(CreateFill());
        }

        private static ICustomAttributeProvider CreateEmpty()
        {
            var assembly = Substitute.For<ICustomAttributeProvider>();

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyCompanyAttribute)), Arg.Is(false))
                          .Returns([AssemblyCompanyAttributeMock.CreateEmpty()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyCopyrightAttribute)), Arg.Is(false))
                          .Returns([AssemblyCopyrightAttributeMock.CreateEmpty()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyDescriptionAttribute)), Arg.Is(false))
                          .Returns([AssemblyDescriptionAttributeMock.CreateEmpty()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyFileVersionAttribute)), Arg.Is(false))
                          .Returns([AssemblyFileVersionAttributeMock.CreateEmpty()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyProductAttribute)), Arg.Is(false))
                          .Returns([AssemblyProductAttributeMock.CreateEmpty()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyTitleAttribute)), Arg.Is(false))
                          .Returns([AssemblyTitleAttributeMock.CreateEmpty()]);

            return assembly;
        }

        private static ICustomAttributeProvider CreateFill()
        {
            var assembly = Substitute.For<ICustomAttributeProvider>();

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyCompanyAttribute)), Arg.Is(false))
                          .Returns([AssemblyCompanyAttributeMock.Create()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyCopyrightAttribute)), Arg.Is(false))
                          .Returns([AssemblyCopyrightAttributeMock.Create()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyDescriptionAttribute)), Arg.Is(false))
                          .Returns([AssemblyDescriptionAttributeMock.Create()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyFileVersionAttribute)), Arg.Is(false))
                          .Returns([AssemblyFileVersionAttributeMock.Create()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyProductAttribute)), Arg.Is(false))
                          .Returns([AssemblyProductAttributeMock.Create()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyTitleAttribute)), Arg.Is(false))
                          .Returns([AssemblyTitleAttributeMock.Create()]);

            assembly.GetCustomAttributes(Arg.Is(typeof(AssemblyVersionAttribute)), Arg.Is(false))
                          .Returns([AssemblyTitleAttributeMock.Create()]);

            return assembly;
        }

        [Fact(DisplayName = "[AssemblyInfo.Title] Deve retornar o title quando o atributo titulo estiver presente.")]
        public void DeveRetornarTitlePreenchidoQuandoAtributoExiste()
            => assemblyInfoFill.Title
                               .Should()
                               .Be(DataMock.TEXT_ASSEMBLY_NAME);

        [Fact(DisplayName = "[AssemblyInfo.Title] Deve retornar string vazia quando o atributo titulo não estiver presente.")]
        public void DeveRetornarTitleVazioQuandoAtributoNaoExiste()
            => assemblyInfoEmpty.Title
                                .Should()
                                .BeEmpty();

        [Fact(DisplayName = "[AssemblyInfo.Version] Deve retornar version quando o atributo titulo estiver presente.")]
        public void DeveRetornarVersionPreenchidoQuandoAtributoExiste()
            => assemblyInfoFill.Version
                               .Should()
                               .Be(DataMock.TEXT_ASSEMBLY_NAME);

        [Fact(DisplayName = "[AssemblyInfo.Version] Deve retornar string vazia quando o atributo titulo não estiver presente.")]
        public void DeveRetornarVersionVazioQuandoAtributoNaoExiste()
            => assemblyInfoEmpty.Version
                                .Should()
                                .BeEmpty();

        [Fact(DisplayName = "[AssemblyInfo.Description] Deve retornar description quando o atributo titulo estiver presente.")]
        public void DeveRetornarDescriptionPreenchidoQuandoAtributoExiste()
            => assemblyInfoFill.Description
                               .Should()
                               .Be(DataMock.TEXT_ASSEMBLY_NAME);

        [Fact(DisplayName = "[AssemblyInfo.Description] Deve retornar string vazia quando o atributo titulo não estiver presente.")]
        public void DeveRetornarDescriptionVazioQuandoAtributoNaoExiste()
            => assemblyInfoEmpty.Description
                                .Should()
                                .BeEmpty();

        [Fact(DisplayName = "[AssemblyInfo.Product] Deve retornar product quando o atributo titulo estiver presente.")]
        public void DeveRetornarProductPreenchidoQuandoAtributoExiste()
            => assemblyInfoFill.Product
                               .Should()
                               .Be(DataMock.TEXT_ASSEMBLY_NAME);

        [Fact(DisplayName = "[AssemblyInfo.Product] Deve retornar string vazia quando o atributo titulo não estiver presente.")]
        public void DeveRetornarProductVazioQuandoAtributoNaoExiste()
            => assemblyInfoEmpty.Product
                                .Should()
                                .BeEmpty();

        [Fact(DisplayName = "[AssemblyInfo.Copyright] Deve retornar copyright quando o atributo titulo estiver presente.")]
        public void DeveRetornarCopyrightPreenchidoQuandoAtributoExiste()
            => assemblyInfoFill.Copyright
                               .Should()
                               .Be(DataMock.TEXT_ASSEMBLY_NAME);

        [Fact(DisplayName = "[AssemblyInfo.Copyright] Deve retornar string vazia quando o atributo titulo não estiver presente.")]
        public void DeveRetornarCopyrightVazioQuandoAtributoNaoExiste()
            => assemblyInfoEmpty.Copyright
                                .Should()
                                .BeEmpty();

        [Fact(DisplayName = "[AssemblyInfo.Company] Deve retornar company quando o atributo titulo estiver presente.")]
        public void DeveRetornarCompanyPreenchidoQuandoAtributoExiste()
            => assemblyInfoFill.Company
                               .Should()
                               .Be(DataMock.TEXT_ASSEMBLY_NAME);

        [Fact(DisplayName = "[AssemblyInfo.Company] Deve retornar string vazia quando o atributo titulo não estiver presente.")]
        public void DeveRetornarCompanyVazioQuandoAtributoNaoExiste()
            => assemblyInfoEmpty.Company
                                .Should()
                                .BeEmpty();

        [Fact(DisplayName = "[AssemblyInfo.Constructor] Deve utilizar o assembly default quando o contrutor receber null.")]
        public void DeveUtilizarAssemblyDefaultQuandoConstrutorReceberNull()
        {
            var assemblyInfo = new AssemblyInfo(null);

            assemblyInfo.Product
                        .Should()
                        .NotBeEmpty();
        }

        [Fact(DisplayName = "[AssemblyInfo.Constructor] Deve retornar string vazia quando não existe attribute no assembly informado.")]
        public void DeveRetornarVazioQuandoAtributoNaoExiste()
        {
            var assembly = Substitute.For<ICustomAttributeProvider>();
            var assemblyInfo = new AssemblyInfo(assembly);

            assemblyInfo.Product
                        .Should()
                        .BeEmpty();
        }
    }
}