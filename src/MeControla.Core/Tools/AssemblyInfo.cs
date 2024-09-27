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

using MeControla.Core.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace MeControla.Core.Tools
{
    /// <summary>
    /// Retrieves metadata information from an assembly.
    /// </summary>
    /// <remarks>
    /// This class is designed to retrieve information about an assembly, using the provided
    /// <see cref="ICustomAttributeProvider"/> to access custom attributes.
    /// If the given assembly is null, it will be the library's own assembly.
    /// </remarks>
    /// <param name="assembly"></param>
    public class AssemblyInfo(ICustomAttributeProvider assembly)
    {
        private readonly ICustomAttributeProvider assembly = assembly ?? Assembly.GetExecutingAssembly();

        /// <summary>
        /// Assembly title
        /// </summary>
        public string Title
        {
            get
            {
                var title = GetValueFromAssembly<AssemblyTitleAttribute>(itm => itm.Title);
                return title.IsNullOrWhiteSpace()
                     ? Path.GetFileNameWithoutExtension(AppContext.BaseDirectory)
                     : title;
            }
        }

        /// <summary>
        /// Assembly version
        /// </summary>
        public string Version => GetValueFromAssembly<AssemblyFileVersionAttribute>(itm => itm.Version);

        /// <summary>
        /// Assembly description
        /// </summary>
        public string Description => GetValueFromAssembly<AssemblyDescriptionAttribute>(itm => itm.Description);

        /// <summary>
        /// Assembly product name
        /// </summary>
        public string Product => GetValueFromAssembly<AssemblyProductAttribute>(itm => itm.Product);

        /// <summary>
        /// Assembly copyright info
        /// </summary>
        public string Copyright => GetValueFromAssembly<AssemblyCopyrightAttribute>(itm => itm.Copyright);

        /// <summary>
        /// Assembly company name
        /// </summary>
        public string Company => GetValueFromAssembly<AssemblyCompanyAttribute>(itm => itm.Company);

        private string GetValueFromAssembly<T>(Func<T, string> predicate)
        {
            var attributes = GetAssemblyCustomAttributes<T>();

            if (attributes.Length == 0)
                return string.Empty;

            var value = predicate((T)attributes[0]);

            return value.IsNullOrWhiteSpace()
                 ? string.Empty
                 : value;
        }

        private object[] GetAssemblyCustomAttributes<T>()
            => assembly.GetCustomAttributes(typeof(T), false);
    }
}