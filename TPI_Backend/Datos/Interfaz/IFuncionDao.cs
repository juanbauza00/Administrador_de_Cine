using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Entidades;
using static TPI_Backend.Entidades.Funcion;

namespace TPI_Backend.Datos.Interfaz
{
    public interface IFuncionDao
    {
        public bool ActualizarFuncion(Funcion oFuncion);
        public bool BorrarFuncion(int numero);
        public bool CrearFuncion(Funcion oFuncion);
        List<Funcion> ObtenerFunciones(DateTime fecha_dede, DateTime fecha_hasta);
        public int ValidarTieneButaca(int idFuncion);
        List<FormatoFuncion> ObtenerFormatosFunciones();

        List<Funcion> ObtenerFuncionesNoParam();

        Funcion ObtenerFuncionesFB(int idFuncionButaca);
    }
}
