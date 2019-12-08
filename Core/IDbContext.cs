using System;
using Microsoft.EntityFrameworkCore;

namespace eateasyapi.Core
{
    public interface IDataBaseContext
    {
        DbContext Instance { get; }
    }
}