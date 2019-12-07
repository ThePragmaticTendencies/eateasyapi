using eateasyapi.Core;
using Microsoft.EntityFrameworkCore;

namespace eateasyapi.Models
{
    public class IngredientContext : DbContext, IEntityDbContext<Ingredient>
    {
        public IngredientContext(DbContextOptions<IngredientContext> options)
            : base(options)
        {
        }

        public DbContext Instance => this;

        public DbSet<Ingredient> Entities { get; set; }     
    }
}