using eateasyapi.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepositoryAsync<TEntity> where TEntity : Entity
{
    Task<TEntity> GetById(Guid id);

    Task<IEnumerable<TEntity>> Get(int pageSize, int page);

    void Insert(TEntity entity);

    void Delete(TEntity entity);

    void Update(TEntity entity);

    bool ExistsById(Guid id);
}