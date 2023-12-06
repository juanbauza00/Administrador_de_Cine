using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Backend.Entidades
{
    public class Funcion
    {
        public int NroFuncion { get; set; }
        
        public DateTime FechaHora { get; set; }
        public Pelicula PeliculaFuncion { get; set; }
        public SalaCine Sala { get; set; }
        
        public FormatoFuncion Formato { get; set; }


        public enum TipoSala
        {
            Sala2D = 1,
            Sala3D = 2,
            SalaVIP = 3,
            SalaIMAX = 4,
            Sala4D = 5,
        }

        public enum FormatoFuncion
        {
            Subtitulada = 1,
            Traducida = 2
        }
        

        public Funcion()
        {
            NroFuncion = 0;
            FechaHora = DateTime.Now;
            PeliculaFuncion = new Pelicula();
            Sala = new SalaCine();
            Formato = FormatoFuncion.Subtitulada;
        }

        public Funcion(int nroFuncion, DateTime fecha, Pelicula peli, SalaCine sala, FormatoFuncion formato)
        {
            NroFuncion = nroFuncion;
            FechaHora = fecha;
            PeliculaFuncion = peli;
            Sala = sala;
            Formato = formato;
        }

        public override string ToString()
        {
            return NroFuncion.ToString() + ' ' + FechaHora;
        }
    }
}

