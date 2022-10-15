using System;
using System.Collections.Generic;

namespace WeCount.Data.Helpers
{
    public interface ICRUD<TEntity>
    {
        public List<TEntity> GetEntities();

        public TEntity GetEntity(int Id);

        public int DeleteEntity(int Id);

        public TEntity InsertEntity(TEntity entity);

        public TEntity UpdateEntity(int Id, TEntity entity);
    }
}
