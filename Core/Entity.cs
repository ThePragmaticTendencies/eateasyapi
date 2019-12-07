using System;

namespace eateasyapi.Core
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}