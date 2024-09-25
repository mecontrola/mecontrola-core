/***********************************************************************************
 * Copyright 2024 Me Controla
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ***********************************************************************************/

using MeControla.Core.Extensions.DataStorage;
using System;
using System.Linq.Expressions;

namespace MeControla.Core.Tools
{
    /// <summary>
    /// Tool used to standardize the naming of tables and columns, applied when creating Entity Framework migrations.
    /// </summary>
    /// <remarks>
    /// Generator for table and column names to be used in persistence tools, aiming to standardize the nomenclature.
    /// It is necessary to provide the schema name and define a prefix that will be used to generate table names.
    /// </remarks>
    /// <typeparam name="TEntity">Entity to be mapped</typeparam>
    /// <param name="schemaName">Schema name</param>
    /// <param name="prefixColumn">Fixed prefix</param>
    public class TableMetadata<TEntity>(string schemaName, string prefixColumn)
        where TEntity : class
    {
        private readonly string schemaName = schemaName;
        private readonly string prefixTable = schemaName.GetPrefixTable();
        private readonly string prefixColumn = string.IsNullOrWhiteSpace(prefixColumn)
                                             ? typeof(TEntity).Name.GetPrefixColumn()
                                             : prefixColumn;

        /// <summary>
        /// Generator for table and column names to be used in persistence tools, aiming to standardize the nomenclature.
        /// It is necessary to provide the schema name, and the prefix will be automatically generated for use in table names.
        /// </summary>
        /// <param name="schemaName">Schema name</param>
        public TableMetadata(string schemaName)
           : this(schemaName, null)
        { }

        /// <summary>
        /// Retorna o nome do schema que será utilizado na criação no banco de dados.
        /// </summary>
        /// <returns>Retorna o nome do schema</returns>
        public string GetSchemaName()
            => schemaName;

        /// <summary>
        /// Returns the table name that will be used in the database creation.
        /// </summary>
        /// <returns>Returns the table name</returns>

        public string GetTableName()
            => typeof(TEntity).Name
                              .GetColumnName(prefixTable);

        /// <summary>
        /// Returns the column name that will be used in the database creation.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="propertyExpression">Expression that identifies the property.</param>
        /// <returns>Returns the column name</returns>
        public string GetColumnName<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
            => ((MemberExpression)propertyExpression.Body).Member
                                                          .Name
                                                          .GetColumnName(prefixColumn);
    }
}