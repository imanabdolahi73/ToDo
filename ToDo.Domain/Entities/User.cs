using System;
using System.Collections.Generic;

namespace ToDo.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();

    public virtual ICollection<UserLogin> UserLogins { get; } = new List<UserLogin>();

    public virtual ICollection<UserToken> UserTokens { get; } = new List<UserToken>();
}
