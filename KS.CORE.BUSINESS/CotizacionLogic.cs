using KS.CORE.DATAMANAGER;
using KS.CORE.ENTITIES;
using System.Collections.Generic;

namespace KS.CORE.BUSINESS
{
    public class CotizacionLogic
    {
        private IGetRepository<CotizacionRequestDTO, CotizacionResponseDTO> _cotizacionRequest;

        public CotizacionLogic(IGetRepository<CotizacionRequestDTO, CotizacionResponseDTO> repository)
        {
            _cotizacionRequest = repository;
        }

        public ResponseDTO<IEnumerable<CotizacionResponseDTO>> Get(CotizacionRequestDTO request)
        {
            return _cotizacionRequest.Get(request);
        }
    }
}
