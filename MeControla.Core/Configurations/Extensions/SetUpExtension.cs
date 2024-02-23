using MeControla.Core.Extensions;
using MeControla.Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MeControla.Core.Configurations.Extensions
{
    public static class SetUpExtension
    {
        [RequiresUnreferencedCode("Calls System.Reflection.Assembly.ExportedTypes")]
        public static void AddApplicationServices(this IServiceCollection services)
            => LoadAssemblies<IInjector>().ForEach(installer => installer.RegisterServices(services));

        [RequiresUnreferencedCode("Calls System.Reflection.Assembly.ExportedTypes")]
        private static IEnumerable<T> LoadAssemblies<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>()
            => LoadAppAssemblies().Select(itm => GetClassFromType<T>(itm))
                                  .SelectMany(x => x);

        [RequiresUnreferencedCode("Calls System.Reflection.Assembly.ExportedTypes")]
        private static IEnumerable<T> GetClassFromType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>(Assembly assembly)
            => assembly.ExportedTypes
                       .Where(x => IsTypeOfClass<T>(x))
                       .Select(Activator.CreateInstance)
                       .Cast<T>();

        private static bool IsTypeOfClass<T>(Type type)
            => typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract;

        private static IEnumerable<Assembly> LoadAppAssemblies()
        {
            var currentAppDomain = GetAppDomainCurrentDomain(null);

            return new DirectoryInfo(currentAppDomain.BaseDirectory).GetFiles("*.dll", SearchOption.TopDirectoryOnly)
                                                                    .Select(itm => GetAssembly(itm, currentAppDomain))
                                                                    .Where(itm => itm != null);
        }

#if DEBUG
    public
#else
    private
#endif
        static Assembly GetAssembly(FileInfo itm, INetCoreAppDomain currentAppDomain)
        {
            var assemblyName = AssemblyName.GetAssemblyName(itm.FullName);
            try
            {
                return currentAppDomain.Load(assemblyName);
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

        private  static INetCoreAppDomain GetAppDomainCurrentDomain(INetCoreAppDomain baseAppDomain)
            => baseAppDomain ?? new NetCoreAppDomain();
    }

    public interface INetCoreAppDomain
    {
        public string BaseDirectory { get; }

        Assembly Load(AssemblyName assemblyRef);
    }

    internal class NetCoreAppDomain : INetCoreAppDomain
    {
        private readonly AppDomain baseAppDomain = AppDomain.CurrentDomain;

        public string BaseDirectory => baseAppDomain.BaseDirectory;

        public Assembly Load(AssemblyName assemblyRef)
            => baseAppDomain.Load(assemblyRef);
    }
}