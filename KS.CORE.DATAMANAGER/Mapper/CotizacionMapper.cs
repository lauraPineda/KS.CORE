﻿using KS.CORE.ENTITIES;
using KS.CORE.SHARED;
using System.Collections.Generic;
using System.Data.Common;

namespace KS.CORE.DATAMANAGER.Mapper
{
    public class CotizacionMapper
    {

        public static ResponseDTO<List<CotizacionResponseDTO>> MapperCotizacionResponseDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<List<CotizacionResponseDTO>> response = new ResponseDTO<List<CotizacionResponseDTO>>();
            response.Result = new List<CotizacionResponseDTO>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.Add(new CotizacionResponseDTO
                    {
                        IdServicio = Helper.GetUInt16(DbDataReader, "IdServicio"),
                        sDescripcion = Helper.GetString(DbDataReader, "Descripcion"),
                        dPrecioServicio = Helper.GetDecimal(DbDataReader, "PrecioServicio"),
                        dPrecioConDescuento = Helper.GetDecimal(DbDataReader, "PrecioConDescuento")
                    });
                }

            }
            else
            {
                response.Success = false;
                response.Message = "Ha ocurrido un error al obtener la cotización";
            }
            return response;

        }
    }
}
