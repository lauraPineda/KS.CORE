using KS.CORE.DATA;
using KS.CORE.ENTITIES;
using KS.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.CORE.DATAMANAGER
{
    public class OrdenRequest : IRepository<string, OrdenRequestDTO, int>
    {
        #region "Global variables"
        Database database;
        DatabaseType databaseType;
        #endregion

        #region "Constructor"
        public OrdenRequest()
        {
            databaseType = DatabaseType.SqlServer;
        }
        #endregion

        #region "Interface Implementation"

        public ResponseDTO<string> Add(OrdenRequestDTO entity)
        {
            ResponseDTO<string> response = new ResponseDTO<string>();
            response.Success = true;

            database = DatabaseFactory.CreateDataBase(databaseType, "[ORDEN].[USP_ADD_ORDEN]", entity.sNombre,
                                                                                                entity.sApellidos,
                                                                                                entity.sTelefono,
                                                                                                entity.sEmail,
                                                                                                entity.sRazonSocial,
                                                                                                entity.bIcluyeIVA,
                                                                                                Helper.ToDataTable(entity.tServicios),
                                                                                                entity.sCodigoDescuento);

            response = CommonMapper.MapperIdString(database.DataReader);


            database.Connection.Close();

            response.Message = CommonMapper.MapperOutput(database);
            return response;

        }

        public ResponseDTO<IEnumerable<OrdenRequestDTO>> GetAll(int filter)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<OrdenRequestDTO> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<string> Update(OrdenRequestDTO entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
