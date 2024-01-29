using FluentAssertions;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using MeControla.Core.Tools;
using Xunit;

namespace MeControla.Core.Tests.Tools
{
    public class TableMetadataTests
    {
        private TableMetadata<ClassTest> metadataTool;

        public TableMetadataTests()
            => metadataTool = new TableMetadata<ClassTest>("test_core");

        [Fact(DisplayName = "[TableMetadata.GetSchemaName] Deve gerar o nome da tabela a partir do tipo da classe informada no construtor acrescido do prefixo.")]
        public void DeveGerarNomeSchema()
            => metadataTool.GetSchemaName()
                           .Should()
                           .BeEquivalentTo("test_core");

        [Fact(DisplayName = "[TableMetadata.GetTableName] Deve gerar o nome da tabela a partir do tipo da classe informada no construtor acrescido do prefixo.")]
        public void DeveGerarNomeTabelaDaTipoClasseInformadoComPrefixo()
            => metadataTool.GetTableName()
                           .Should()
                           .BeEquivalentTo("tc_class_test");

        [Fact(DisplayName = "[TableMetadata.GetColumnName] Deve gerar o nome da columna a partir da propriedade da classe informada no construtor acrescido do prefixo.")]
        public void DeveGerarNomeColunaDaPropriedadeClasseInformadaComPrefixo()
            => metadataTool.GetColumnName(x => x.FieldInClass1)
                           .Should()
                           .BeEquivalentTo("clts_field_in_class1");

        [Fact(DisplayName = "[TableMetadata.GetColumnName] Deve gerar o nome da columna utilizando o prefixo informado no construtor.")]
        public void DeveGerarNomeColunaDaPropriedadeComPrefixoInformado()
        {
            metadataTool = new TableMetadata<ClassTest>("test_core", "cst");
            metadataTool.GetColumnName(x => x.FieldInClass1)
                        .Should()
                        .BeEquivalentTo("cst_field_in_class1");
        }

        [Fact(DisplayName = "[TableMetadata.GetColumnName] Deve gerar o nome da columna utilizando o prefixo informado no construtor que contenha somente duas consoantes.")]
        public void DeveGerarNomeColunaDaPropriedadeComPrefixoInformado2()
        {
            var tool = new TableMetadata<Movie>("test_core");
            tool.GetColumnName(x => x.FieldInClass1)
                .Should()
                .BeEquivalentTo("mve_field_in_class1");
        }
    }
}