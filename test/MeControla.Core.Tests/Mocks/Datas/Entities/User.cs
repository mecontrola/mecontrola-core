using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeControla.Core.Tests.Mocks.Datas.Entities;

public class User : IEntity
{
    public long Id { get; set; }
    public Guid Uuid { get; set; }
    [Required]
    public string Name { get; set; }
    public IList<UserPermission> UserPermissions { get; set; }
}