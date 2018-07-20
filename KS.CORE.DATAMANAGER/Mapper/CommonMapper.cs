﻿using KS.CORE.ENTITIES;
using KS.CORE.SHARED;
using System.Collections.Generic;
using System.Data.Common;

namespace KS.CORE.DATAMANAGER
{
    public class CommonMapper
    {
        /// <summary>
        /// Realiza mapeo del Id obtenido de un data reader
        /// </summary>
        /// <param name="DbDataReader">Data reader</param>
        /// <returns>ResponseDTO<int></returns>
        public static ResponseDTO<int> MapperId(DbDataReader DbDataReader)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                    response.Result = Helper.GetInt32(DbDataReader, "Id");
            }
            else
            {
                response.Success = false;
                response.Message = "Ocurrió un error al obtener el Id.";
            };

            return response;
        }

        /// <summary>
        /// Realiza mapeo de los elementos de una clase CatalogsDTO de un data reader
        /// </summary>
        /// <param name="DbDataReader"Data reader></param>
        /// <returns>ResponseDTO<List<CatalogsDTO>></returns>
        public static ResponseDTO<List<CatalogsDTO>> CatalogsMapper(DbDataReader DbDataReader)
        {
            ResponseDTO<List<CatalogsDTO>> response = new ResponseDTO<List<CatalogsDTO>>();
            response.Result = new List<CatalogsDTO>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.Add(new CatalogsDTO
                    {
                        Id = Helper.GetInt32(DbDataReader, "Id"),
                        Name = Helper.GetString(DbDataReader, "Nombre"),
                        Description = Helper.GetString(DbDataReader, "Descipcion"),
                        Enabled = Helper.GetBoolean(DbDataReader, "Activo")
                    });
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Ocurrió un error al cargar el catálogp.";
            };
            return response;
        }

        /// <summary>
        /// Obtiene el numero de cambios registrados 
        /// </summary>
        /// <param name="DbDataReader"></param>
        /// <returns></returns>
        public static ResponseDTO<int> GetRecordsAffected(DbDataReader DbDataReader)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();

            response.Result = DbDataReader.RecordsAffected;

            //Si el número de cambios registrados es menor o igual a se indica que ocurrio un error al realizar la modificación
            response.Success = response.Result > 0 ? true : false;

            response.Message = response.Success == false ? "Ocurrió un error al actualizar." : null;
            return response;
        }

    }
}
