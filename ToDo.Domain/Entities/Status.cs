using System;
using System.Collections.Generic;

namespace ToDo.Domain.Entities;

public partial class Status
{
    public int StatusId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
