using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Entidades;

namespace TPI_Backend.Datos.Interfaz
{
     public interface IPeliculaDao
    {
        List<Pelicula> GetPeliculas();

        List<SalaCine> GetSalas();
    }
}
