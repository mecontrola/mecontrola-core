using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories
{
    public interface IDbAppContext : IDbContext
    {
        DbSet<User> Users { get; }
    }
}