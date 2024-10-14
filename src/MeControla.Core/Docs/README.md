# Repository

[![Licence](https://img.shields.io/badge/license-Apache%202-blue)](license.txt) [![NuGet](https://img.shields.io/nuget/v/mecontrola.core.svg)](https://www.nuget.org/packages/mecontrola.core) [![NuGet](https://img.shields.io/nuget/dt/mecontrola.core.svg)](https://www.nuget.org/packages/mecontrola.core) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=coverage)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core)

|| Build | Coverage | CodeQL |
| ------ | ------ | ------ | ------ |
| Main | [![.NET](https://github.com/mecontrola/mecontrola.core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mecontrola/mecontrola.core/actions/workflows/dotnet.yml) | [![Coverage Status](https://coveralls.io/repos/github/mecontrola/mecontrola.core/badge.svg?branch=main)](https://coveralls.io/github/mecontrola/mecontrola.core?branch=main) | [![CodeQL](https://github.com/mecontrola/mecontrola.core/actions/workflows/codeql-analysis.yml/badge.svg?branch=main)](https://github.com/mecontrola/mecontrola.core/actions/workflows/codeql-analysis.yml) |

## Me Controla Core

Me Controla Core is a simple and versatile solution designed to streamline everyday implementations in any type of C# application. Our library offers a collection of essential features that can be easily integrated into various projects, ranging from small desktop applications to large enterprise systems.

MeControla.Core was created with the goal of simplifying common development tasks by providing intuitive and efficient tools to speed up your work. Whether you are developing a WPF application, ASP.NET MVC, or any other C# platform, our library fits perfectly with your needs.

Explore the following sections to learn how to install, configure, and use MeControla.Core efficiently. With practical examples and a complete API reference, you'll be ready to make the most of the features offered, turning your ideas into reality with more speed and less effort.

### Installation
Installing Me Controla Core is quick and easy through NuGet, the package manager for .NET. You can install the library directly into your project using the following method:

```sh
dotnet add package MeControla.Core
```
Use the `--version` option to specify a [pre-release version](https://www.nuget.org/packages/mecontrola.core/absoluteLatest) to install.

### Basic Usage
The following code demonstrates the basic usage of the Me Controla Core library to create a Builder that assists in the creation of a User object. For more information, please refer to the documentation.

```cs
using MeControla.Core;

// Basic usage example of the Builder to create a User object.
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool Active { get; set; }
}

public class UserBuilder : BaseBuilder<UserBuilder, User>, IBuilder<User>
{
    protected override void FillDefaultValues(User obj)
        => obj.Active = true;

    public UserBuilder WithName(string value)
        => Set(obj => obj.Name = value);

    public UserBuilder WithAge(int value)
        => Set(obj => obj.Age = value);
}

class Program
{
    static void Main()
    {
        User user = UserBuilder.GetInstance()
                               .WithName("John Doe")
                               .WithAge(30)
                               .ToBuild();

        Console.WriteLine($"User: {user.Name}, Age: {user.Age}, Active: {(user.Active ? "Yes" ; "No")}");
    }
} //Result: User: John Doe, Age: 30, Active: Yes
```

## License
This and other projects are maintained by [Me Controla](https://mecontrola.com) and licensed under the [Apache License, Version 2.0](license.txt).