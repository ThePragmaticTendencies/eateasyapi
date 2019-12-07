using System;
using Microsoft.EntityFrameworkCore;

namespace eateasyapi.Core
{
    public interface IDbContext
    {
        DbContext Instance { get; }
    }
}