using KS.CORE.BUSINESS;
using KS.CORE.DATAMANAGER;
using KS.CORE.ENTITIES;
using KS.CORE.SHARED;
using System.Web.Http;

namespace KS.CORE.WEBAPI.Controllers
{
    public class OrdenController : ApiController
    {
        #region "Global variables"
        OrdenLogic ordenLogic;
        #endregion

        #region "Constructor"
        public OrdenController(IRepository<string, OrdenRequestDTO, int> repository)
        {
            ordenLogic = new OrdenLogic(repository);
        }
        #endregion


        [HttpPost]
        public ResponseDTO<string> Add(RequestDTO<OrdenRequestDTO> request)
        {
            var response = new ResponseDTO<string>();
            try
            {
                response = ordenLogic.Add(request.Signature);
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
