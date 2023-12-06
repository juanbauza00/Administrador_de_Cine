using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Entidades;

namespace TPI_Backend.Datos.Interfaz
{
    public interface ITicketDao
    {
        int ObtenerProximoTicket();
        bool CrearTicket(Ticket oTicket);
        bool ActualizarTicket(Ticket oTicket);
        
        List<Ticket> ObtenerTicketsPorFiltros(List<Parametro> lFiltros);
        Dictionary<int, int> ObtenerDescuento(int dia_semana);
        List<Butaca> ObtenerButacas(int id_funcion);
        List<Ticket.FormaPagoTicket> ObtenerFormasPago();
        List<Ticket> TraerTickets();
        List<Ticket> TraerTicketsConFecha(DateTime fechaDesde, DateTime fechaHasta);

        bool BorrarTicket(int idTicket);
    }
}
