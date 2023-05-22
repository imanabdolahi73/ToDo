using System;
using System.Collections.Generic;

namespace ToDo.Domain.Entities;

public partial class UserLogin
{
    public int LoginProviderId { get; set; }

    public string ProviderKey { get; set; } = null!;

    public string ProviderDisplayName { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserToken> UserTokens { get; } = new List<UserToken>();
}
