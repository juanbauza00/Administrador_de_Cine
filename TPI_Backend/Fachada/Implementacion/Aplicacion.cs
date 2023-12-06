using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Datos.Implementacion;
using TPI_Backend.Datos.Interfaz;
using TPI_Backend.Entidades;
using TPI_Backend.Fachada.Interfaz;
using static TPI_Backend.Entidades.Cliente;
using static TPI_Backend.Entidades.Funcion;

namespace TPI_Backend.Fachada.Implementacion
{
    public class Aplicacion : IAplicacion
    {
        private ITicketDao ticketDao;
        private IGerenteDao gerenteDao;
        private IClienteDao clienteDao;
        private IFuncionDao funcionDao;
        private IPeliculaDao peliculaDao;
        public Aplicacion()
        {
            ticketDao = new TicketDao();
            gerenteDao = new GerenteDao();
            clienteDao = new ClienteDao();
            funcionDao = new FuncionDao();
            peliculaDao = new PeliculaDao();
        }
        public List<Cliente> GetClientes()
        {
            return clienteDao.ObtenerClientes();
        }

        public List<Funcion> GetFunciones(DateTime fecha_desde, DateTime fecha_hasta)
        {
            
            return funcionDao.ObtenerFunciones(fecha_desde,fecha_hasta);
        }

        public bool SaveTicket(Ticket oTicket)
        {
            return ticketDao.CrearTicket(oTicket);
        }

        public List<Gerente> GetGerentes() {
            return gerenteDao.GetGerentes();

        }

        public int validarPassword(string email, string password) {
            
            return gerenteDao.validarPassword(email, password);
            
        }
        public bool BorrarCliente(int idcliente)
        {
            return clienteDao.DeleteCliente(idcliente);

        }

        public List<tipoDocumentoCliente> GetTiposDocumentos() {
            return clienteDao.GetTiposDocumentos();
        }

        public bool GuardarCliente(Cliente nuevoCliente) {
            return clienteDao.CrearCliente(nuevoCliente);


            
        }

        public bool GuardarFuncion(Funcion nuevaFuncion)
        {
            return funcionDao.CrearFuncion(nuevaFuncion);
        }

        public List<Pelicula> ObtenerPeliculas()
        {
            return peliculaDao.GetPeliculas();
        }

        public List<SalaCine> ObtenerSalas() {
            return peliculaDao.GetSalas();
        }

        public List<FormatoFuncion> ObtenerFormatosFunciones() {
            return funcionDao.ObtenerFormatosFunciones();
        }

        public List<Cliente> GetClientes(DateTime fecha_desde, DateTime fecha_hasta)
        {
            return clienteDao.ObtenerClientes(fecha_desde, fecha_hasta);
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            return clienteDao.UpdateCliente(cliente);
        }

        public int ValidarTieneTicket(int idCliente) {

            return clienteDao.ValidarTieneTicket(idCliente);
        }

        public bool BorrarFuncion(int idFuncion)
        {
            return funcionDao.BorrarFuncion(idFuncion);
        }

        public int ValidarTieneButaca(int idFuncion)
        {
            return funcionDao.ValidarTieneButaca(idFuncion);
        }

        public Dictionary<int, int> GetDescuento(int dia_semana)
        {
            return ticketDao.ObtenerDescuento(dia_semana);
        }

        public List<Butaca> GetButacas(int id_funcion)
        {
            return ticketDao.ObtenerButacas(id_funcion);
        }

        public List<Ticket.FormaPagoTicket> GetFomasPago()
        {
            return ticketDao.ObtenerFormasPago();
        }

        public bool UpdateTicket(Ticket oTicket)
        {
            return ticketDao.ActualizarTicket(oTicket);
        }

        public List<Ticket> GetTickets()
        {
            return ticketDao.TraerTickets();
        }

        public List<Ticket> GetTicketsConFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return ticketDao.TraerTicketsConFecha(fechaDesde, fechaHasta);
        }

        public bool ActualizarFuncion(Funcion funcion) {
            return funcionDao.ActualizarFuncion(funcion);
        }

        public List<Funcion> GetFunciones()
        {
            return funcionDao.ObtenerFuncionesNoParam();
        }
        public Funcion GetFuncionesFB(int idFuncionButaca)
        {
            return funcionDao.ObtenerFuncionesFB(idFuncionButaca);
        }

        public bool BorrarTicket(int idTicket)
        {
            return ticketDao.BorrarTicket(idTicket);
        }
    }
}
