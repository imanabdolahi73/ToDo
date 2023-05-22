using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Application.Interfaces.Context
{
    public interface IToDoContext
    {
        DbSet<Role> Roles { get; set; }

        DbSet<RoleClaim> RoleClaims { get; set; }

        DbSet<Status> Statuses { get; set; }

        DbSet<ToDo.Domain.Entities.Task> Tasks { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<UserLogin> UserLogins { get; set; }

        DbSet<UserToken> UserTokens { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
