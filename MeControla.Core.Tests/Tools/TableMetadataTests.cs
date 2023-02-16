using FluentAssertions;
using MeControla.Core.Tests.Datas.Mocks.Entities;
using MeControla.Core.Tools;
using Xunit;

namespace MeControla.Core.Tests.Tools
{
    public class TableMetadataTests
    {
        private TableMetadata<ClassTest> tool;

        public TableMetadataTests()
            => tool = new TableMetadata<ClassTest>("test_core");

        [Fact(DisplayName = "[TableMetadata.GetSchemaName] Deve gerar o nome da tabela a partir do tipo da classe informada no construtor acrescido do prefixo.")]
        public void DeveGerarNomeSchema()
            => tool.GetSchemaName()
                   .Should()
                   .BeEquivalentTo("test_core");

        [Fact(DisplayName = "[TableMetadata.GetTableName] Deve gerar o nome da tabela a partir do tipo da classe informada no construtor acrescido do prefixo.")]
        public void DeveGerarNomeTabelaDaTipoClasseInformadoComPrefixo()
            => tool.GetTableName()
                   .Should()
                   .BeEquivalentTo("tc_class_test");

        [Fact(DisplayName = "[TableMetadata.GetColumnName] Deve gerar o nome da columna a partir da propriedade da classe informada no construtor acrescido do prefixo.")]
        public void DeveGerarNomeColunaDaPropriedadeClasseInformadaComPrefixo()
            => tool.GetColumnName(x => x.FieldInClass1)
                   .Should()
                   .BeEquivalentTo("clts_field_in_class1");

        [Fact(DisplayName = "[TableMetadata.GetColumnName] Deve gerar o nome da columna utilizando o prefixo informado no construtor.")]
        public void DeveGerarNomeColunaDaPropriedadeComPrefixoInformado()
        {
            tool = new TableMetadata<ClassTest>("test_core", "cst");
            tool.GetColumnName(x => x.FieldInClass1)
                .Should()
                .BeEquivalentTo("cst_field_in_class1");
        }
    }
}