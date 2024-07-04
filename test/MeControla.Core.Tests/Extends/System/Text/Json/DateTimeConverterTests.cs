using FluentAssertions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using MeControla.Core.Tests.Mocks.Entities;
using System.Text.Json;
using Xunit;

namespace MeControla.Core.Tests.Extends.System.Text.Json
{
    public class DateTimeConverterTests
    {
        private const string DATE_FORMAT = "yyyyMMddHHmmss";

        private readonly JsonSerializerOptions options;

        public DateTimeConverterTests()
        {
            options = new();
            options.Converters.Add(new DateTimeConverter(DATE_FORMAT));
        }

        [Fact(DisplayName = "[DateTimeConverter.Read/Write] Deve retornar o nome dos atributos no formato snake case.")]
        public void DeveRetornarAtributoQuandoExistir()
        {
            var actualString = JsonSerializer.Serialize(ClassTestMock.Create(), options);
            var expectedString = DataMock.JSON_CLASS_WITH_DATE_TEST;

            actualString.Should().NotBeNull();
            actualString.Should().BeOfType<string>();
            actualString.Should().BeEquivalentTo(expectedString);

            var actualClass = JsonSerializer.Deserialize<ClassTest>(actualString, options);
            var expectedClass = ClassTestMock.Create();

            actualClass.Should().NotBeNull();
            actualClass.Should().BeOfType<ClassTest>();
            actualClass.Should().BeEquivalentTo(expectedClass);
        }
    }
}