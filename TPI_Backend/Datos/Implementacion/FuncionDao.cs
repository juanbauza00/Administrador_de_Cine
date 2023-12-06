using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Entidades;
using TPI_Backend.Datos.Interfaz;
using System.Diagnostics;
using static TPI_Backend.Entidades.Funcion;
using System.Runtime.InteropServices;
using static TPI_Backend.Entidades.Pelicula;
using System.Linq.Expressions;

namespace TPI_Backend.Datos.Implementacion
{
    public class FuncionDao : IFuncionDao
    {
        public bool ActualizarFuncion(Funcion oFuncion)
        {
            bool success = true;
            int afectadas = 0;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@id_funcion", oFuncion.NroFuncion));
            parametros.Add(new Parametro("@id_pelicula", oFuncion.PeliculaFuncion.Id_Pelicula));
            parametros.Add(new Parametro("@fecha_hora", oFuncion.FechaHora));
            parametros.Add(new Parametro("@id_formato", (int)oFuncion.Formato));
            parametros.Add(new Parametro("@id_sala", (int)oFuncion.Sala.TipoSala));
            try
            {
                afectadas = HelperDao.ObtenerInstancia().EjecutarSQL("SP_MODIFICAR_MAESTRO_FUNCIONES", parametros);

            }
            catch (SqlException ex) {
                Debug.WriteLine(ex.Message);
            }
            return afectadas > 0;
        }

        public bool BorrarFuncion(int numero)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@idFuncion", numero));

                HelperDao.ObtenerInstancia().EjecutarSQL("SP_ELIMINAR_FUNC_BUTACA", parametros);
            
            
            

            string sp = "SP_ELIMINAR_FUNCION";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@id_funcion", numero));

            int afectadas = 0;
            try
            {

                afectadas = HelperDao.ObtenerInstancia().EjecutarSQL(sp, lst);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return afectadas > 0;
        }

        public bool CrearFuncion(Funcion oFuncion)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_FUNCION";
                //Parametros input
                comando.Parameters.AddWithValue("@id_pelicula", oFuncion.PeliculaFuncion.Id_Pelicula);
                comando.Parameters.AddWithValue("@fecha_hora", oFuncion.FechaHora);
                comando.Parameters.AddWithValue("@id_formato", oFuncion.Formato);
                comando.Parameters.AddWithValue("@id_sala", oFuncion.Sala.TipoSala);
                //Parametro output
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@id_funcion";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);
                
                
                
                comando.ExecuteNonQuery();
                
                


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
        public List<Funcion> ObtenerFunciones(DateTime fecha_desde, DateTime fecha_hasta) //Work in progress
        {

            List<Funcion> listaFunciones = new List<Funcion>();
            List<Parametro> paramsFunciones = new List<Parametro>();
            paramsFunciones.Add(new Parametro("@fecha_desde", fecha_desde));
            paramsFunciones.Add(new Parametro("@fecha_hasta", fecha_hasta));


            DataTable tablaFunciones =
                HelperDao.ObtenerInstancia().
                Consultar("SP_CONSULTAR_FUNCIONES", paramsFunciones);

            try
            {

                foreach (DataRow rowFunciones in tablaFunciones.Rows)
                {

                    Funcion nuevafuncion = new Funcion();
                    nuevafuncion.NroFuncion = int.Parse(rowFunciones["id_funcion"].ToString());

                    nuevafuncion.FechaHora = Convert.ToDateTime(rowFunciones["fecha_hora"].ToString());

                    List<Parametro> paramsPeliculas = new List<Parametro>();
                    paramsPeliculas.Add(new Parametro("@idPelicula", int.Parse(rowFunciones["id_pelicula"].ToString())));
                    DataTable tablaPeliculas = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_PELICULA_ID", paramsPeliculas);

                    foreach (DataRow peliculaRow in tablaPeliculas.Rows)
                    {
                        Pelicula nuevaPelicula = new Pelicula();
                        nuevaPelicula.Id_Pelicula = int.Parse(peliculaRow["id_pelicula"].ToString());
                        nuevaPelicula.Nombre = peliculaRow["nombre"].ToString();
                        nuevaPelicula.Descripcion = peliculaRow["descripcion"].ToString();
                        nuevaPelicula.Duracion = int.Parse(peliculaRow["duracion"].ToString());

                        List<Parametro> paramsGeneros = new List<Parametro>();
                        paramsGeneros.Add(new Parametro("@idPelicula", nuevaPelicula.Id_Pelicula));
                        DataTable tablaGeneros = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_GENERO_ID", paramsGeneros);
                        DataRow rowGeneros = tablaGeneros.Rows[0];
                        nuevaPelicula.Genero = (GeneroPelicula)rowGeneros["id_genero"];
                        

                        List<Parametro> paramsCategorias = new List<Parametro>();
                        paramsCategorias.Add(new Parametro("@idPelicula", nuevaPelicula.Id_Pelicula));
                        DataTable tablaCategorias = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_CATEGORIAS_ID",paramsCategorias);
                        DataRow rowCategorias = tablaCategorias.Rows[0];
                        nuevaPelicula.Categoria = (CategoriaPelicula)int.Parse(rowCategorias["id_categoria"].ToString());

                        nuevafuncion.PeliculaFuncion = nuevaPelicula;

                    }

                    List<Parametro> paramsSala = new List<Parametro>();
                    paramsSala.Add(new Parametro("@idSala", rowFunciones["id_sala"]));
                    DataTable tablaSalas = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_SALAS_ID", paramsSala);

                    DataRow rowSala = tablaSalas.Rows[0];

                    SalaCine nuevaSala = new SalaCine(
                        int.Parse(rowSala["id_sala"].ToString()),
                        (SalaCine.TipoSalaCine)rowSala["id_sala"],
                        double.Parse(rowSala["precio"].ToString())
                        );
                    nuevafuncion.Sala = nuevaSala;

                    List<Parametro> paramsFormato = new List<Parametro>();
                    paramsFormato.Add(new Parametro("@idFormato", rowFunciones["id_formato"].ToString()));
                    DataTable tablaFormatos = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_FORMATOS_ID", paramsFormato);
                    DataRow rowFormato = tablaFormatos.Rows[0];
                    nuevafuncion.Formato = (FormatoFuncion)int.Parse(rowFormato["id_formato"].ToString());

                    listaFunciones.Add(nuevafuncion);

                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

            }
            return listaFunciones;
        }

        public List<FormatoFuncion> ObtenerFormatosFunciones() {

            List<FormatoFuncion> listaFormatoFuncion = new List<FormatoFuncion>();

            DataTable tablaFormatoFuncion = HelperDao.ObtenerInstancia().Consultar("SP_OBTENER_FORMATOS_FUNCIONES");
            foreach (DataRow row in tablaFormatoFuncion.Rows)
            {
                FormatoFuncion nuevoFormato = (FormatoFuncion)int.Parse(row["id_formato"].ToString());
                listaFormatoFuncion.Add(nuevoFormato);
            }
            return listaFormatoFuncion;
            
        }

        public int ValidarTieneButaca(int idFuncion)
        {
            int validacion;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@idFuncion", idFuncion));
            validacion = HelperDao.ObtenerInstancia().ConsultarEscalar("SP_FUNCION_TIENE_RESERVA", "@tiene", parametros);
            return validacion;
        }

        public List<Funcion> ObtenerFuncionesNoParam()
        {
            List<Funcion> lFunciones = new List<Funcion>();
            DataTable tablaFunciones = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_FUNCIONES_NO_PARAM");
            try
            {
                foreach (DataRow fila in tablaFunciones.Rows)
                {
                    Funcion nuevafuncion = new Funcion();
                    nuevafuncion.NroFuncion = int.Parse(fila["id_funcion"].ToString());
                    nuevafuncion.FechaHora = Convert.ToDateTime(fila["fecha_hora"].ToString());

                    List<Parametro> paramPeliculas = new List<Parametro>();
                    paramPeliculas.Add(new Parametro("@idPelicula", int.Parse(fila["id_pelicula"].ToString())));
                    DataTable tablaPeliculas = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_PELICULA_ID", paramPeliculas);
                    foreach (DataRow peliculaRow in tablaPeliculas.Rows)
                    {
                        Pelicula nuevaPelicula = new Pelicula();
                        nuevaPelicula.Id_Pelicula = int.Parse(peliculaRow["id_pelicula"].ToString());
                        nuevaPelicula.Nombre = peliculaRow["nombre"].ToString();
                        nuevaPelicula.Descripcion = peliculaRow["descripcion"].ToString();
                        nuevaPelicula.Duracion = int.Parse(peliculaRow["duracion"].ToString());

                        List<Parametro> paramsGeneros = new List<Parametro>();
                        paramsGeneros.Add(new Parametro("@idPelicula", nuevaPelicula.Id_Pelicula));
                        DataTable tablaGeneros = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_GENERO_ID", paramsGeneros);
                        DataRow rowGeneros = tablaGeneros.Rows[0];
                        nuevaPelicula.Genero = (GeneroPelicula)rowGeneros["id_genero"];


                        List<Parametro> paramsCategorias = new List<Parametro>();
                        paramsCategorias.Add(new Parametro("@idPelicula", nuevaPelicula.Id_Pelicula));
                        DataTable tablaCategorias = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_CATEGORIAS_ID", paramsCategorias);
                        DataRow rowCategorias = tablaCategorias.Rows[0];
                        nuevaPelicula.Categoria = (CategoriaPelicula)int.Parse(rowCategorias["id_categoria"].ToString());
                        nuevafuncion.PeliculaFuncion = nuevaPelicula;

                    }
                    List<Parametro> paramsSala = new List<Parametro>();
                    paramsSala.Add(new Parametro("@idSala", fila["id_sala"]));
                    DataTable tablaSalas = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_SALAS_ID", paramsSala);

                    DataRow rowSala = tablaSalas.Rows[0];

                    SalaCine nuevaSala = new SalaCine(
                        int.Parse(rowSala["id_sala"].ToString()),
                        (SalaCine.TipoSalaCine)rowSala["id_sala"],
                        double.Parse(rowSala["precio"].ToString())
                        );
                    nuevafuncion.Sala = nuevaSala;

                    List<Parametro> paramsFormato = new List<Parametro>();
                    paramsFormato.Add(new Parametro("@idFormato", fila["id_formato"].ToString()));
                    DataTable tablaFormatos = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_FORMATOS_ID", paramsFormato);
                    DataRow rowFormato = tablaFormatos.Rows[0];
                    nuevafuncion.Formato = (FormatoFuncion)int.Parse(rowFormato["id_formato"].ToString());

                    lFunciones.Add(nuevafuncion);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lFunciones;
        }

        public Funcion ObtenerFuncionesFB(int idFuncionButaca)
        {
            List<Funcion> listaFunciones = new List<Funcion>();
            Funcion funcion = new Funcion();
            List<Parametro> paramFunciones = new List<Parametro>();
            paramFunciones.Add(new Parametro("@idFuncionButaca", idFuncionButaca));

            DataTable tablaFunciones = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_FUNCION_ID_FUNCIONBUTACA", paramFunciones);
            try
            {
                foreach (DataRow rowFunciones in tablaFunciones.Rows)
                {
                    Funcion nuevafuncion = new Funcion();
                    nuevafuncion.NroFuncion = int.Parse(rowFunciones["id_funcion"].ToString());

                    nuevafuncion.FechaHora = Convert.ToDateTime(rowFunciones["fecha_hora"].ToString());

                    List<Parametro> paramsPeliculas = new List<Parametro>();
                    paramsPeliculas.Add(new Parametro("@idPelicula", int.Parse(rowFunciones["id_pelicula"].ToString())));
                    DataTable tablaPeliculas = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_PELICULA_ID", paramsPeliculas);

                    foreach (DataRow peliculaRow in tablaPeliculas.Rows)
                    {
                        Pelicula nuevaPelicula = new Pelicula();
                        nuevaPelicula.Id_Pelicula = int.Parse(peliculaRow["id_pelicula"].ToString());
                        nuevaPelicula.Nombre = peliculaRow["nombre"].ToString();
                        nuevaPelicula.Descripcion = peliculaRow["descripcion"].ToString();
                        nuevaPelicula.Duracion = int.Parse(peliculaRow["duracion"].ToString());

                        List<Parametro> paramsGeneros = new List<Parametro>();
                        paramsGeneros.Add(new Parametro("@idPelicula", nuevaPelicula.Id_Pelicula));
                        DataTable tablaGeneros = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_GENERO_ID", paramsGeneros);
                        DataRow rowGeneros = tablaGeneros.Rows[0];
                        nuevaPelicula.Genero = (GeneroPelicula)rowGeneros["id_genero"];


                        List<Parametro> paramsCategorias = new List<Parametro>();
                        paramsCategorias.Add(new Parametro("@idPelicula", nuevaPelicula.Id_Pelicula));
                        DataTable tablaCategorias = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_CATEGORIAS_ID", paramsCategorias);
                        DataRow rowCategorias = tablaCategorias.Rows[0];
                        nuevaPelicula.Categoria = (CategoriaPelicula)int.Parse(rowCategorias["id_categoria"].ToString());

                        nuevafuncion.PeliculaFuncion = nuevaPelicula;

                    }

                    List<Parametro> paramsSala = new List<Parametro>();
                    paramsSala.Add(new Parametro("@idSala", rowFunciones["id_sala"]));
                    DataTable tablaSalas = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_SALAS_ID", paramsSala);

                    DataRow rowSala = tablaSalas.Rows[0];

                    SalaCine nuevaSala = new SalaCine(
                        int.Parse(rowSala["id_sala"].ToString()),
                        (SalaCine.TipoSalaCine)rowSala["id_sala"],
                        double.Parse(rowSala["precio"].ToString())
                        );
                    nuevafuncion.Sala = nuevaSala;

                    List<Parametro> paramsFormato = new List<Parametro>();
                    paramsFormato.Add(new Parametro("@idFormato", rowFunciones["id_formato"].ToString()));
                    DataTable tablaFormatos = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_FORMATOS_ID", paramsFormato);
                    DataRow rowFormato = tablaFormatos.Rows[0];
                    nuevafuncion.Formato = (FormatoFuncion)int.Parse(rowFormato["id_formato"].ToString());
                    funcion = nuevafuncion;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return funcion;


        }
    }
}
