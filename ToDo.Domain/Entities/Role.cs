using System;
using System.Collections.Generic;

namespace ToDo.Domain.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<RoleClaim> RoleClaims { get; } = new List<RoleClaim>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
