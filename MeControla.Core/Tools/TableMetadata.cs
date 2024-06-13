using MeControla.Core.Extensions.DataStorage;
using System;
using System.Linq.Expressions;

namespace MeControla.Core.Tools
{
    public class TableMetadata<TEntity>(string schemaName, string prefixColumn)
        where TEntity : class
    {
        private readonly string schemaName = schemaName;
        private readonly string prefixTable = schemaName.GetPrefixTable();
        private readonly string prefixColumn = string.IsNullOrWhiteSpace(prefixColumn)
                                             ? typeof(TEntity).Name.GetPrefixColumn()
                                             : prefixColumn;

        public TableMetadata(string schemaName)
           : this(schemaName, null)
        { }

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