using FluentAssertions;
using MeControla.Core.Mappers;
using MeControla.Core.Tests.Datas.Mocks.Enums;
using MeControla.Core.Tests.Mocks.Datas.Dtos;
using MeControla.Core.Tests.Mocks.Dtos;
using MeControla.Core.Tests.Mocks.Enums;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Mappers
{
    public sealed class BaseEnumToDtoMapperTests
    {
        private readonly IEnumToDtoMapper<EnumTest, EnumTestDto> mapper;

        public BaseEnumToDtoMapperTests()
        {
            mapper = new EnumTestDtoToDtoMapper();
        }

        [Fact(DisplayName = "[EnumTestDtoToDtoMapper.ToMap] Deve retornar null quando informado null.")]
        public void DeveRetornarNuloQuandoForNulo()
        {
            var actual = mapper.ToMap(EnumTestMock.CreateEmpty());

            Assert.Null(actual);
        }

        [Fact(DisplayName = "[EnumTestDtoToDtoMapper.ToMap] Deve retornar dto quando informado entidade preenchido.")]
        public void DeveRetornarPreenchidoQuandoPreenchido()
        {
            var entity = EnumTestMock.CreateElement1();
            var expected = EnumTestDtoMock.CreateElement1();
            var actual = mapper.ToMap(entity);

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact(DisplayName = "[EnumTestDtoToDtoMapper.ToMap] Deve retornar dto quando informado entidade preenchido.")]
        public void DeveRetornarAlteradoQuandoPreenchidoComOutraObjeto()
        {
            var entity = EnumTestMock.CreateElement1();
            var expected = EnumTestDtoMock.CreateElement1();
            var actual = mapper.ToMap(entity, EnumTestDtoMock.CreateElement2());

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact(DisplayName = "[EnumTestDtoToDtoMapper.ToMap] Deve retornar lista de dtos quando informado lista de entidades preenchidas.")]
        public void DeveRetornarListaPreenchidaQuandoPreenchida()
        {
            var entity = EnumTestMock.CreateElement1();
            var expected = new List<EnumTestDto> { EnumTestDtoMock.CreateElement1() };
            var actual = mapper.ToMapList(new List<EnumTest> { entity });

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact(DisplayName = "[EnumTestDtoToDtoMapper.ToMap] Deve retornar um objeto utilizando o mapeamento padrão.")]
        public void DeveRetornarObjetoUtilizandoMapeamentoPadrao()
        {
            var entity = EnumTestMock.CreateElement1();
            var expected = EnumTestDtoMock.CreateElement1();
            var actual = new EnumTestDtoToDtoMapper().ToMap(entity);

            expected.Should().BeEquivalentTo(actual);
        }
    }

    class EnumTestDtoToDtoMapper : BaseEnumToDtoMapper<EnumTest, EnumTestDto>
    { }
}
