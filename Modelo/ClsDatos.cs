﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Modelo
{
    public class ClsDatos
    {
        #region Declaracion de variables

        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter daAdaptador = null;
        DataTable Dtt = null;
        string strCadenaConexion = string.Empty;
        #endregion

        #region Cadena Conexion
        public ClsDatos()
        {
            this.strCadenaConexion = @"Data Source=SALA403-16\SQLEXPRESS;Initial Catalog=bdolimpiadas;Integrated Security=True";
        }
        #endregion

        public DataTable RetornaTabla(SqlParameter[] parParametros, string parTSQL)
        {
            Dtt = null;
            try
            {
                Dtt = new DataTable();

                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parTSQL;

                if (parParametros != null)
                {
                    cmdComando.Parameters.AddRange(parParametros);
                }

                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.Fill(Dtt);
            }
            catch (Exception ex)
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }
            return Dtt;
        }

        public void EjecutarSP(SqlParameter[] parametros, string spNombre)
        {
            try
            {
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cnnConexion.Open();
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = spNombre;
                cmdComando.Parameters.AddRange(parametros);
                cmdComando.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                
            }
        }

    }
}
