using System;
using System.Collections.Generic;

namespace ToDo.Domain.Entities;

public partial class UserToken
{
    public int UserTokenId { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Value { get; set; }

    public int? LoginProviderId { get; set; }

    public virtual UserLogin? LoginProvider { get; set; }

    public virtual User? User { get; set; }
}
