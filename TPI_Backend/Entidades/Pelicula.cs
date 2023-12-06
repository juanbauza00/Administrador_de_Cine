using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Backend.Entidades
{
    public class Pelicula
    {
        public int Id_Pelicula { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }

        public GeneroPelicula Genero { get; set; }
        public CategoriaPelicula Categoria { get; set; }
        public enum CategoriaPelicula
        {
            ATP = 1,
            M13,
            M16,
            M18
        }

        public enum GeneroPelicula
        {
            Accion = 1,
            Terror,
            Documental,
            Suspenso,
            Infantil,
            Comedia,
            Romance
        }

        public Pelicula()
        {
            Id_Pelicula = 0;
            Nombre = "";
            Descripcion = "";
            Duracion = 0;
            Categoria = CategoriaPelicula.ATP;
            Genero = GeneroPelicula.Infantil;
        }

        public Pelicula(int id, string nombre, string desc, int duracion, CategoriaPelicula cat, GeneroPelicula genero)
        {
            Id_Pelicula = id;
            Nombre = nombre;
            Descripcion = desc;
            Duracion = duracion;
            Categoria = cat;
            Genero = genero;
        }

        public string DuracionHrsMin()
        {
            string hrs = (Duracion / 60).ToString() + "hs";
            string min = (60 * (Duracion % 60)).ToString() + " min";
            string duracion = hrs + " " + min;
            return duracion;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
