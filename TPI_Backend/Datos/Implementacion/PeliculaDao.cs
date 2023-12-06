using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Datos.Interfaz;
using TPI_Backend.Entidades;
using System.Diagnostics;
using System.ComponentModel;
using static TPI_Backend.Entidades.SalaCine;

namespace TPI_Backend.Datos.Implementacion
{
    public class PeliculaDao : IPeliculaDao
    {
        public List<Pelicula> GetPeliculas()
        {
           List<Pelicula> peliculas = new List<Pelicula>();
            DataTable tablaPeliculas = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_PELICULAS");
            if(tablaPeliculas.Rows.Count > 0) 
            {
                foreach (DataRow row in tablaPeliculas.Rows)
                {
                    Pelicula nuevaPelicula = new Pelicula();
                    nuevaPelicula.Id_Pelicula = int.Parse(row["id_pelicula"].ToString());
                    nuevaPelicula.Nombre = row["nombre"].ToString();
                    nuevaPelicula.Descripcion = row["descripcion"].ToString();
                    nuevaPelicula.Duracion = Convert.ToInt32((int)row["duracion"]);
                    int idCategoriaDataBase= Convert.ToInt32(row["id_categoria"]);
                    nuevaPelicula.Categoria = (Pelicula.CategoriaPelicula)idCategoriaDataBase;
                    int idGeneroDataBase = Convert.ToInt32(row["id_genero"]);
                    nuevaPelicula.Genero = (Pelicula.GeneroPelicula)idGeneroDataBase;
                    peliculas.Add(nuevaPelicula);


                }
               
            }
            return peliculas;
        }

        public List<SalaCine> GetSalas() {
            List<SalaCine> salas = new List<SalaCine>();
            DataTable tablaSalas = null;
            tablaSalas = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_SALAS"); 
            
            
            foreach (DataRow row in tablaSalas.Rows) {
                SalaCine nuevaSala = new SalaCine();
                nuevaSala.NroSala = int.Parse(row["id_sala"].ToString());
                nuevaSala.TipoSala = (TipoSalaCine)int.Parse(row["id_tipo_sala"].ToString());
                nuevaSala.Precio = double.Parse(row["precio"].ToString());
                salas.Add(nuevaSala);
            }
            return salas;
        }
    }
}
