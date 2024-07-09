using MeControla.Core.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace MeControla.Core.Tools
{
    /// <summary>
    /// Recovery assembly informations
    /// </summary>
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
