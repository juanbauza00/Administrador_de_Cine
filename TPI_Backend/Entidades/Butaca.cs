using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Backend.Entidades
{
    public class Butaca
    {
        //Debido a que cada butaca depende según la funcion se debe establecer el IdButacaFuncion
        
        public int IdFuncionButaca { get; set; }
        public int IdButaca { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }

        public EstadoButaca Estado { get; set; }
        public enum EstadoButaca
        {
            Desocupada = 0,
            Ocupada = 1
        }
    }
}
