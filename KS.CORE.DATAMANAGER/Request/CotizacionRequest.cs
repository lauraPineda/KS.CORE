using KS.CORE.DATA;
using KS.CORE.DATAMANAGER.Mapper;
using KS.CORE.ENTITIES;
using KS.CORE.SHARED;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace KS.CORE.DATAMANAGER
{
    public class CotizacionRequest : IGetRepository<CotizacionRequestDTO, CotizacionResponseDTO>
    {
        #region "Global variables"
        Database database;
        DatabaseType databaseType;
        #endregion

        #region "Constructor"
        public CotizacionRequest()
        {
            databaseType = DatabaseType.SqlServer;
        }
        #endregion

        #region "Interface Implementation"

        public ResponseDTO<IEnumerable<CotizacionResponseDTO>> Get(CotizacionRequestDTO request)
        {
            ResponseDTO<IEnumerable<CotizacionResponseDTO>> response = new ResponseDTO<IEnumerable<CotizacionResponseDTO>>();
            ResponseDTO<List<CotizacionResponseDTO>> responseList = Get(Helper.ToDataTable(request.tServicios),request.sCodigoDescuento);

            response.Message = responseList.Message;
            response.Success = responseList.Success;

            if (responseList.Success)
                response.Result = responseList.Result.AsEnumerable();

            return response;
        }
        #endregion

        #region "Methods"
        private ResponseDTO<List<CotizacionResponseDTO>> Get(DataTable IdServicios, string CodigoServicio)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[ORDEN].[USP_GET_COTIZACION]", IdServicios, CodigoServicio);
            ResponseDTO<List<CotizacionResponseDTO>> response = CotizacionMapper.MapperCotizacionResponseDTO(database.DataReader);
            database.Connection.Close();

            response.Message= CommonMapper.MapperOutput(database);
            return response;
        }
        #endregion
    }
}
