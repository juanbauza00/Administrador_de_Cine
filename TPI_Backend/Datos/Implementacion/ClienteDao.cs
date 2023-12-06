using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Entidades;
using TPI_Backend.Datos.Interfaz;
using static TPI_Backend.Entidades.Cliente;
using System.Diagnostics;

namespace TPI_Backend.Datos.Implementacion
{
    public class ClienteDao : IClienteDao
    {
        public bool UpdateCliente(Cliente oCliente)
        {
            bool ok = true;
            SqlConnection cnn = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand comando = new SqlCommand();

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                comando.Connection = cnn;
                comando.Transaction = t;
                comando.CommandText = "SP_MODIFICAR_MAESTRO_CLIENTE";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_cliente", oCliente.IdCliente);
                comando.Parameters.AddWithValue("@nom_cliente", oCliente.Nombre);
                comando.Parameters.AddWithValue("@ape_cliente", oCliente.Apellido);
                comando.Parameters.AddWithValue("@documento", oCliente.Documento);
                comando.Parameters.AddWithValue("@id_tipo_documento", oCliente.TipoDocumento);

                //SqlParameter parametro = new SqlParameter();
                //parametro.ParameterName = "@id_cliente";
                //parametro.SqlDbType = SqlDbType.Int;
                //parametro.Direction = ParameterDirection.;
                //comando.Parameters.Add(parametro);
                
                
                
                comando.ExecuteNonQuery();
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool BorrarCliente(int documento)
        {
            string sp = "SP_ELIMINAR_CLIENTE"; 
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@documento", documento));
            int afectadas = HelperDao.ObtenerInstancia().EjecutarSQL(sp, lst);
            return afectadas > 0;
        }

        public bool CrearCliente(Cliente nuevoCliente)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_CLIENTE";

                //parametros de entrada
                comando.Parameters.AddWithValue("@nom_cliente", nuevoCliente.Nombre);
                comando.Parameters.AddWithValue("@ape_cliente", nuevoCliente.Apellido);
                comando.Parameters.AddWithValue("@documento", nuevoCliente.Documento);
                comando.Parameters.AddWithValue("@id_tipo_documento", (int)nuevoCliente.TipoDocumento);

                //parametro salida (id cliente, el identity insertado)
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@id_cliente";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int ticketNro = (int)parametro.Value;               
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return resultado;
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lClientes = new List<Cliente>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_CLIENTES_NO_PARAM"); //Obtener Clientes

            foreach (DataRow f in tabla.Rows)
            {
                int idCliente = int.Parse(f["id_cliente"].ToString());
                string nomCliente = Convert.ToString(f["nom_cliente"]);
                string apeCliente = Convert.ToString(f["ape_cliente"]);
                int documento = int.Parse(f["documento"].ToString());
                tipoDocumentoCliente tipoDoc = (tipoDocumentoCliente)int.Parse(f["id_tipo_documento"].ToString());
                Cliente cliente = new Cliente(idCliente, nomCliente, apeCliente, documento, tipoDoc);
                lClientes.Add(cliente);

            }
            return lClientes;
        }

        public List<tipoDocumentoCliente> GetTiposDocumentos() {
            List<tipoDocumentoCliente> listaTipoDocumento = new List<tipoDocumentoCliente>();

            DataTable tablaTiposDocumentos = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_TIPOS_DOCUMENTOS");
            foreach (DataRow row in tablaTiposDocumentos.Rows) 
            {
                tipoDocumentoCliente tipo = (tipoDocumentoCliente)int.Parse(row["id_tipo_documento"].ToString());
                listaTipoDocumento.Add(tipo);
            }
            return listaTipoDocumento;
        }

        public List<Cliente> ObtenerClientes(DateTime fecha_desde, DateTime fecha_hasta)

        


        {
            List<Cliente> lClientes = new List<Cliente>();
            List<Parametro> paramClientes = new List<Parametro>();
            paramClientes.Add(new Parametro("@fecha_desde", fecha_desde));
            paramClientes.Add(new Parametro("@fecha_hasta", fecha_hasta));
            DataTable tablaClientes = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_CLIENTES_PARAM", paramClientes);
            try
            {
                foreach (DataRow filaClientes in tablaClientes.Rows)
                {
                    Cliente newCliente = new Cliente();
                    newCliente.IdCliente = int.Parse(filaClientes["id_cliente"].ToString());
                    newCliente.Nombre = filaClientes["nom_cliente"].ToString();
                    newCliente.Apellido = filaClientes["ape_cliente"].ToString();
                    newCliente.Documento = int.Parse(filaClientes["documento"].ToString());

                    List<Parametro> paramTipoDoc = new List<Parametro>();
                    paramTipoDoc.Add(new Parametro("@id_tipo_documento", filaClientes["id_tipo_documento"].ToString()));
                    DataTable tablaTipoDoc = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_TIPO_DOC_ID", paramTipoDoc);
                    DataRow filaTipoDoc = tablaTipoDoc.Rows[0];
                    newCliente.TipoDocumento = (tipoDocumentoCliente)int.Parse(filaTipoDoc["id_tipo_documento"].ToString());
                    lClientes.Add(newCliente);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lClientes;
        }
        public bool DeleteCliente(int idcliente )
        {
            string sp = "SP_ELIMINAR_CLIENTE";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@id_cliente", idcliente));
            int afectadas = HelperDao.ObtenerInstancia().EjecutarSQL(sp, lst);
            return afectadas > 0;
        }

        public int ValidarTieneTicket(int idCliente) {
            int success;

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@idCliente", idCliente));
            success = HelperDao.ObtenerInstancia().ConsultarEscalar("SP_CLIENTE_TIENE_TICKET", "@tiene", parametros);
            return success;
        }


    }
}
