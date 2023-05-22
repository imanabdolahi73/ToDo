using System;
using System.Collections.Generic;

namespace ToDo.Domain.Entities;

public partial class Task
{
    public int TaskId { get; set; }

    public string Title { get; set; } = null!;

    public int UserId { get; set; }

    public int StatusId { get; set; }

    public DateTime InsertDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public DateTime? RemoveDateTime { get; set; }

    public bool? IsRemoved { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
