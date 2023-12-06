using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Backend.Entidades
{
    public class DetalleTicket
    {
        public int IdDetalleTicket { get; set; }
        public double Precio_Unitario { get; set; }

        //El diccionario Descuento se carga con una clave int que representa el día, Lunes = 1 por ejemplo.
        //y un valor float que define el descuento para ese día en porcentaje. 10 = 10% 
        public Dictionary<int, double> Descuento { get; set; } 

        public Butaca Butaca { get; set; }  
        public DetalleTicket(int idDetalle, int pre_unit, Dictionary<int, double> descuento)
        {
            IdDetalleTicket = idDetalle;
            Precio_Unitario = pre_unit;
            Descuento = descuento;
        }

        public DetalleTicket() { }
        //calcular sub total (?
    }
}
