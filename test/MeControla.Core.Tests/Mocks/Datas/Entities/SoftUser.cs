using MeControla.Core.Data.Entities;
using System;

namespace MeControla.Core.Tests.Mocks.Datas.Entities;

public class SoftUser : ISoftEntity
{
    public long Id { get; set; }
    public Guid Uuid { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
}