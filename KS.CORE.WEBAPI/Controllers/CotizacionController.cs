using KS.CORE.BUSINESS;
using KS.CORE.DATAMANAGER;
using KS.CORE.ENTITIES;
using KS.CORE.SHARED;
using System.Collections.Generic;
using System.Web.Http;

namespace KS.CORE.WEBAPI.Controllers
{
    public class CotizacionController : ApiController
    {
        #region "Global variables"
        CotizacionLogic cotizacionLogic;
        #endregion

        #region "Constructor"
        public CotizacionController(IGetRepository<CotizacionRequestDTO, CotizacionResponseDTO> repository)
        {
            cotizacionLogic = new CotizacionLogic(repository);
        }
        #endregion

        [HttpPost]
        public ResponseDTO<IEnumerable<CotizacionResponseDTO>> GetCotizacion(RequestDTO<CotizacionRequestDTO> request)
        {
            var response = new ResponseDTO<IEnumerable<CotizacionResponseDTO>>();
            try
            {
                response = cotizacionLogic.Get(request.Signature);

            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                ExceptionHandler.Instance.WriteExceptionLog(exception);
            }
            catch (System.Exception exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                ExceptionHandler.Instance.WriteExceptionLog(exception);
            }
            return response;
        }
    }
}
