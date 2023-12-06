using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Entidades;
using static TPI_Backend.Entidades.Cliente;
using static TPI_Backend.Entidades.Funcion;
using static TPI_Backend.Entidades.Ticket;

namespace TPI_Backend.Fachada.Interfaz
{
    public interface IAplicacion
    {
        List<Cliente> GetClientes();
        bool SaveTicket(Ticket oTicket);
        List<Funcion> GetFunciones(DateTime fecha_desde, DateTime fecha_hasta);
        List<Cliente> GetClientes(DateTime fecha_desde, DateTime fecha_hasta);
        List<Gerente> GetGerentes();

        int validarPassword(string email, string password);

        bool BorrarCliente(int idcliente);

        List<tipoDocumentoCliente> GetTiposDocumentos();

        bool GuardarCliente(Cliente nuevoCliente);
        bool GuardarFuncion(Funcion nuevaFuncion);
        List<Pelicula> ObtenerPeliculas();

        List<SalaCine> ObtenerSalas();

        List<FormatoFuncion> ObtenerFormatosFunciones();
        bool ActualizarCliente(Cliente cliente);

        int ValidarTieneTicket(int idCliente);
        bool BorrarFuncion(int idFuncion);
        int ValidarTieneButaca(int idFuncion);
        Dictionary<int, int> GetDescuento(int dia_semana);

        List<Butaca> GetButacas(int id_funcion);

        List<FormaPagoTicket> GetFomasPago();

        bool UpdateTicket(Ticket oTicket);

        List<Ticket> GetTickets();
        List<Ticket> GetTicketsConFecha(DateTime fechaDesde, DateTime fechaHasta);

        bool ActualizarFuncion(Funcion funcion);

        List<Funcion> GetFunciones();

        Funcion GetFuncionesFB(int idFuncionButaca);

        bool BorrarTicket(int idTicket);
    }
}
