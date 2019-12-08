using System;
using eateasyapi.Models;
using Microsoft.EntityFrameworkCore;

namespace eateasyapi.Core
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbContext Instance => this;

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
        
    }
}