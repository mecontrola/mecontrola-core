# Repositório

[![Licence](https://img.shields.io/badge/license-Apache%202-blue)](license.txt) [![NuGet](https://img.shields.io/nuget/v/mecontrola.core.svg)](https://www.nuget.org/packages/mecontrola.core) [![NuGet](https://img.shields.io/nuget/dt/mecontrola.core.svg)](https://www.nuget.org/packages/mecontrola.core) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=coverage)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core) [![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=mecontrola_mecontrola.core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=mecontrola_mecontrola.core)

|| Build | Coverage | CodeQL |
| ------ | ------ | ------ | ------ |
| Main | [![.NET](https://github.com/mecontrola/mecontrola.core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mecontrola/mecontrola.core/actions/workflows/dotnet.yml) | [![Coverage Status](https://coveralls.io/repos/github/mecontrola/mecontrola.core/badge.svg?branch=main)](https://coveralls.io/github/mecontrola/mecontrola.core?branch=main) | [![CodeQL](https://github.com/mecontrola/mecontrola.core/actions/workflows/codeql-analysis.yml/badge.svg?branch=main)](https://github.com/mecontrola/mecontrola.core/actions/workflows/codeql-analysis.yml) |

## Me Controla Core

O Me Controla Core é uma solução simples e versátil projetada para facilitar as implementações do dia a dia em qualquer tipo de aplicação C#. Nossa biblioteca oferece uma coleção de funcionalidades essenciais que podem ser integradas facilmente em projetos variados, desde pequenos aplicativos desktop até grandes sistemas empresariais.

MeControla.Core foi criada com o objetivo de simplificar as tarefas comuns de desenvolvimento, fornecendo ferramentas intuitivas e eficientes para acelerar o seu trabalho. Quer você esteja desenvolvendo uma aplicação WPF, ASP.NET MVC, ou qualquer outra plataforma C#, nossa biblioteca se adapta perfeitamente às suas necessidades.

Explore as seções a seguir para aprender como instalar, configurar e utilizar MeControla.Core de maneira eficiente. Com exemplos práticos e uma referência completa da API, você estará pronto para aproveitar ao máximo as funcionalidades oferecidas e transformar suas ideias em realidade com mais rapidez e menos esforço.

### Instalação
A instalação da Me Controla Core é simples e rápida através do NuGet, o gerenciador de pacotes para .NET. Você pode instalar a biblioteca diretamente no seu projeto usando os seguinte método:

```sh
dotnet add package MeControla.Core
```
Use a opção `--version` para especificar uma [versão prévia](https://www.nuget.org/packages/mecontrola.core/absoluteLatest) para instalar.

### Uso Básico
O código a seguir demonstra o uso básico da biblioteca Me Controla Core para a criação de um Builder para auxiliar na criação de um objeto User. Para mais informações, consulte a documentação.

```cs
using MeControla.Core;

// Exemplo de uso básico do Builder para criar um objeto User
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
}
```

## Licença
Esse e outros projetos são mantidos pela [Me Controla](https://mecontrola.com) e licenciados sob a [Licença Apache, Versão 2.0](license.txt).