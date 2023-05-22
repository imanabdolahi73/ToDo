using System;
using System.Collections.Generic;

namespace ToDo.Domain.Entities;

public partial class RoleClaim
{
    public int RoleClaimId { get; set; }

    public int RoleId { get; set; }

    public string ClaimType { get; set; } = null!;

    public string ClaimValue { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
