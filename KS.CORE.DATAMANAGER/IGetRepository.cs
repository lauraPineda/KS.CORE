using KS.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.CORE.DATAMANAGER
{
    public interface IGetRepository<TRequest, TResponse>
    {
        ResponseDTO<IEnumerable<TResponse>> Get(TRequest filter);
    }
}
