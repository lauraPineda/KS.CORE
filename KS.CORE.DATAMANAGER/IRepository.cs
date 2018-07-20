using KS.CORE.ENTITIES;
using System.Collections.Generic;

namespace KS.CORE.DATAMANAGER
{
    public interface IRepository<Tkey, TEntity, TFilter>
    {
        ResponseDTO<Tkey> Add(TEntity entity);
        ResponseDTO<Tkey> Update(TEntity entity);
        ResponseDTO<IEnumerable<TEntity>> GetAll(TFilter filter);
        ResponseDTO<TEntity> GetById(Tkey id);
    }

}
