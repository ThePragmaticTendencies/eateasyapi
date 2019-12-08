using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace  eateasyapi.Core
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : Entity
    {
        private readonly IDataBaseContext context;

        private DbContext Instance => context.Instance;

        private DbSet<TEntity> Entities => Instance.Set<TEntity>(); 

        public RepositoryAsync(IDataBaseContext context)
        {
            this.context = context;
        }

        public async void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            await Instance.SaveChangesAsync();
        }

        public bool ExistsById(Guid id)
        {
            return Entities.Any(ingredient => ingredient.Id == id);
        }

        public async Task<IEnumerable<TEntity>> Get(int pageSize, int page)
        {
            return await Entities
                .Skip(pageSize * page)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await Entities.FindAsync(id);
        }

        public async void Insert(TEntity entity)
        {
            Entities.Add(entity);
            await Instance.SaveChangesAsync();
        }

        public async void Update(TEntity entity)
        {
            Instance.Entry(entity).State = EntityState.Modified;
            await Instance.SaveChangesAsync();
        }
    }
}