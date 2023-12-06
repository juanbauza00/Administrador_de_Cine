using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Cine_Frontend.Presentacion
{
    public class TemasColores
    {
        public static void ViewClientConsult(Form formulario, Color colorFondo, FormBorderStyle estiloBordes)
        {
            formulario.BackColor = colorFondo;
            formulario.FormBorderStyle = estiloBordes;

        }
    }
}
