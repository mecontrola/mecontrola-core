using MeControla.Core.Extensions.DataStorage;
using System;
using System.Linq.Expressions;

namespace MeControla.Core.Tools
{
    public class TableMetadata<TEntity>
        where TEntity : class
    {
        private readonly string schemaName;
        private readonly string prefixTable;
        private readonly string prefixColumn;

        public TableMetadata(string schemaName)
           : this(schemaName, null)
        { }

        public TableMetadata(string schemaName, string prefixColumn)
        {
            this.schemaName = schemaName;
            this.prefixColumn = string.IsNullOrWhiteSpace(prefixColumn)
                              ? typeof(TEntity).Name.GetPrefixColumn()
                              : prefixColumn;

            prefixTable = schemaName.GetPrefixTable();
        }

        public string GetSchemaName()
            => schemaName;

        public string GetTableName()
            => typeof(TEntity).Name
                              .GetColumnName(prefixTable);

        public string GetColumnName<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
            => ((MemberExpression)propertyExpression.Body).Member
                                                          .Name
                                                          .GetColumnName(prefixColumn);
    }
}