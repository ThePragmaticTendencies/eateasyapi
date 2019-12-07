using System;
using Microsoft.EntityFrameworkCore;

namespace eateasyapi.Core
{
    public interface IEntityDbContext<TEntity> : IDbContext where TEntity : Entity
    {
        DbSet<TEntity> Entities { get; set; } 
    }
}