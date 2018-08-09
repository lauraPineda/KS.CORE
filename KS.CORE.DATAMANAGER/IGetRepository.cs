using KS.CORE.ENTITIES;
using System.Collections.Generic;

namespace KS.CORE.DATAMANAGER
{
    public interface IGetRepository<TRequest, TResponse>
    {
        ResponseDTO<IEnumerable<TResponse>> Get(TRequest filter);
    }
}
