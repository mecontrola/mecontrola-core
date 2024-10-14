using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Tests.Mocks.Entities;

public static class SoftUserMock
{
    public static SoftUser CreateUser1()
    {
        var dev = CreateUserEmpty();
        dev.Id = DataMock.INT_ID_1;
        dev.Uuid = DataMock.UUID_USER_1;
        dev.Name = DataMock.TEXT_USER_NAME_1;
        return dev;
    }

    public static SoftUser CreateUser2()
    {
        var dev = CreateUserEmpty();
        dev.Id = DataMock.INT_ID_2;
        dev.Uuid = DataMock.UUID_USER_2;
        dev.Name = DataMock.TEXT_USER_NAME_2;
        return dev;
    }

    public static SoftUser CreateUser3()
    {
        var dev = CreateUserEmpty();
        dev.Id = DataMock.INT_ID_3;
        dev.Uuid = DataMock.UUID_USER_3;
        dev.Name = DataMock.TEXT_USER_NAME_3;
        return dev;
    }

    public static SoftUser CreateUser4()
    {
        var dev = CreateUserEmpty();
        dev.Id = DataMock.INT_ID_4;
        dev.Uuid = DataMock.UUID_USER_4;
        dev.Name = DataMock.TEXT_USER_NAME_4;
        return dev;
    }

    public static SoftUser CreateUserEmpty()
        => new();

    public static IList<SoftUser> CreateList()
        => [
            CreateUser1(),
            CreateUser2(),
            CreateUser3()
        ];

    public static IQueryable<SoftUser> CreateQueryable()
        => new List<SoftUser>
        {
            new() { Id = DataMock.INT_ID_1, Name = "John", Age = 25, IsDeleted = false },
            new() { Id = DataMock.INT_ID_2, Name = "Jane", Age = 30, IsDeleted = false },
            new() { Id = DataMock.INT_ID_3, Name = "Johnathan", Age = 35, IsDeleted = false },
            new() { Id = DataMock.INT_ID_4, Name = "Alice", Age = 40, IsDeleted = true }
        }.AsQueryable();
}        