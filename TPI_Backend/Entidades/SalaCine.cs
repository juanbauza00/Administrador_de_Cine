using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Backend.Entidades
{
    public class SalaCine
    {
        public int NroSala { get; set; }
        public TipoSalaCine TipoSala { get; set; }
        public double Precio { get; set; }
        public enum TipoSalaCine
        {
            Sala2D = 1,
            Sala3D,
            VIP,
            IMAX,
            Sala4D
        }

        public SalaCine()
        {
            NroSala = 0;
            TipoSala = TipoSalaCine.Sala2D;
            Precio = 0;
        }

        public SalaCine(int nro, TipoSalaCine tipo, double precio)
        {
            NroSala = nro;
            TipoSala = tipo;
            Precio = precio;
        }

        public override string ToString()
        {
            return "Sala N° " + NroSala;
        }
    }
}
