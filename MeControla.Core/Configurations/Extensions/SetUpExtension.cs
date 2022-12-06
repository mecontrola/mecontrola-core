using MeControla.Core.Extensions;
using MeControla.Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MeControla.Core.Configurations.Extensions
{
    public static class SetUpExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
            => LoadAssemblies<IInjector>().ForEach(installer => installer.RegisterServices(services));

        private static IEnumerable<T> LoadAssemblies<T>()
            => LoadAppAssemblies().Select(itm => GetClassFromType<T>(itm))
                                  .SelectMany(x => x);

        private static IEnumerable<T> GetClassFromType<T>(Assembly assembly)
            => assembly.ExportedTypes
                       .Where(x => IsTypeOfClass<T>(x))
                       .Select(Activator.CreateInstance)
                       .Cast<T>();

        private static bool IsTypeOfClass<T>(Type type)
            => typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract;

        private static IEnumerable<Assembly> LoadAppAssemblies()
            => new DirectoryInfo(GetAppBaseDirectory()).GetFiles("*.dll", SearchOption.TopDirectoryOnly)
                                                       .Select(itm => GetAssembly(itm))
                                                       .Where(itm => itm != null);

        private static Assembly GetAssembly(FileInfo itm)
        {
            var assemblyName = AssemblyName.GetAssemblyName(itm.FullName);
            try
            {
                return AppDomain.CurrentDomain.Load(assemblyName);
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (BadImageFormatException)
            {
                return null;
            }
            catch (AppDomainUnloadedException)
            {
                return null;
            }
            catch (FileLoadException)
            {
                return null;
            }
        }

        private static string GetAppBaseDirectory()
            => AppDomain.CurrentDomain.BaseDirectory;
    }
}