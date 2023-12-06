using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Backend.Datos
{
    public class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection conexion;
        private HelperDao()
        {
            // conexion = new SqlConnection(Properties.Resources.CadenaConexion);
            //conexion = new SqlConnection(@"Data Source=DESKTOP-itskqb8\SQLEXPRESS;Initial Catalog=TPI_Cine;Integrated Security=True");
            //conexion = new SqlConnection(@"Data Source=DESKTOP-D01O5T8\SQLEXPRESS;Initial Catalog=TPI_Cine11;Integrated Security=True");
            conexion = new SqlConnection(@"Data Source=Rafa-pc\SQLEXPRESS;Initial Catalog=TPI_Cine;Integrated Security=True");
            //conexion = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = TPI_Cine; Integrated Security = True");
            //
            //conexion = new SqlConnection(@"Data Source=DESKTOP-7LTGOLV;Initial Catalog=TPI_Cine;Integrated Security=True"); //Casa Juan
        }
        public static HelperDao ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }
        public int ConsultarEscalar(string nombreSP, string nombreParamOut)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombreParamOut;
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;

            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery();

            conexion.Close();

            return (int)parametro.Value;
        }
        public int ConsultarEscalar(
            string nombreSP,
            string nombreParamOut,
            List<Parametro> parametros) {

            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            SqlParameter parametroOut = new SqlParameter();
            parametroOut.ParameterName = nombreParamOut;
            parametroOut.SqlDbType = SqlDbType.Int;
            parametroOut.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parametroOut);
            foreach (Parametro parametro in parametros)
            {
                comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
            }
            comando.ExecuteNonQuery();
            conexion.Close();
            return (int)parametroOut.Value;
            
        }
        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public DataTable Consultar(string nombreSP, List<Parametro> lstParametros)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            comando.Parameters.Clear();
            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public SqlConnection ObtenerConexion()
        {
            return this.conexion;
        }

        public int EjecutarSQL(string strSql, List<Parametro> values)
        {
            int afectadas = 0;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;

                if (values != null)
                {
                    foreach (Parametro param in values)
                    {
                        cmd.Parameters.AddWithValue(param.Nombre, param.Valor);
                    }
                }

                afectadas = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException ex)
            {
                if (t != null) { t.Rollback(); Debug.WriteLine(ex.Message); }
            }
            catch (ArgumentException argEx) { Debug.WriteLine(argEx.Message); }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();

            }
            return afectadas;
        }
    }
}
