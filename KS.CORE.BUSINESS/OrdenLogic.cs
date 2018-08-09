using KS.CORE.DATAMANAGER;
using KS.CORE.ENTITIES;

namespace KS.CORE.BUSINESS
{
    public class OrdenLogic
    {
        private IRepository<string, OrdenRequestDTO, int> _ordenRequest;

        public OrdenLogic(IRepository<string, OrdenRequestDTO, int> repository)
        {
            _ordenRequest = repository;
        }

        public ResponseDTO<string> Add(OrdenRequestDTO request)
        {
            return _ordenRequest.Add(request);
        }
    }
}
