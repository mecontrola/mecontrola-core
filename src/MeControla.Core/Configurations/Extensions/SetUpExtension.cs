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
using MeControla.Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MeControla.Core.Configurations.Extensions;

/// <summary>
/// Provides extension methods for configuring services in a .NET Core application by discovering
/// and registering service injectors from assemblies.
/// </summary>
public static class SetUpExtension
{
    /// <summary>
    /// Registers application-specific services into the provided <see cref="IServiceCollection"/> 
    /// by loading assemblies that implement <see cref="IInjector"/> and invoking their registration methods.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <remarks>
    /// This method dynamically loads assemblies and registers services by invoking implementations of 
    /// <see cref="IInjector"/>. It uses reflection to access the exported types of assemblies, 
    /// which may not work correctly with trimming or AOT (ahead-of-time) compilation, and thus is 
    /// annotated with <see cref="RequiresUnreferencedCodeAttribute"/>.
    /// </remarks>
    /// <exception cref="RequiresUnreferencedCodeAttribute">Indicates that the method may use code that could be removed by the linker.</exception>
    [RequiresUnreferencedCode("Calls System.Reflection.Assembly.ExportedTypes")]
    public static void AddApplicationServices(this IServiceCollection services)
        => LoadAssemblies<IInjector>().ForEach(installer => installer.RegisterServices(services));

    [RequiresUnreferencedCode("Calls System.Reflection.Assembly.ExportedTypes")]
    private static IEnumerable<T> LoadAssemblies<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>()
            => LoadAppAssemblies().Select(GetClassFromType<T>)
                                  .SelectMany(x => x);

    [RequiresUnreferencedCode("Calls System.Reflection.Assembly.ExportedTypes")]
    private static IEnumerable<T> GetClassFromType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>(Assembly assembly)
        => assembly.ExportedTypes
                   .Where(IsTypeOfClass<T>)
                   .Select(Activator.CreateInstance)
                   .Cast<T>();

    private static bool IsTypeOfClass<T>(Type type)
        => typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract;

    private static IEnumerable<Assembly> LoadAppAssemblies()
    {
        var currentAppDomain = GetAppDomainCurrentDomain(null);

        return new DirectoryInfo(currentAppDomain.BaseDirectory).GetFiles("*.dll", SearchOption.TopDirectoryOnly)
                                                                .Select(itm => GetAssembly(itm, currentAppDomain))
                                                                .OfType<Assembly>();
    }

    internal static Assembly? GetAssembly(FileInfo itm, INetCoreAppDomain currentAppDomain)
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

    private static INetCoreAppDomain GetAppDomainCurrentDomain(INetCoreAppDomain? baseAppDomain)
        => baseAppDomain ?? new NetCoreAppDomain();
}

/// <summary>
/// Represents a simplified abstraction of an application domain in a .NET Core application, 
/// providing methods to load assemblies and access base directory information.
/// </summary>
public interface INetCoreAppDomain
{
    /// <summary>
    /// Gets the base directory path where the application is located.
    /// </summary>
    string BaseDirectory { get; }

    /// <summary>
    /// Loads an assembly given its <see cref="AssemblyName"/>.
    /// </summary>
    /// <param name="assemblyRef">The <see cref="AssemblyName"/> representing the assembly to load.</param>
    /// <returns>The loaded <see cref="Assembly"/> instance.</returns>
    Assembly Load(AssemblyName assemblyRef);
}

internal class NetCoreAppDomain : INetCoreAppDomain
{
    private readonly AppDomain baseAppDomain = AppDomain.CurrentDomain;

    public string BaseDirectory => baseAppDomain.BaseDirectory;

    public Assembly Load(AssemblyName assemblyRef)
        => baseAppDomain.Load(assemblyRef);
}