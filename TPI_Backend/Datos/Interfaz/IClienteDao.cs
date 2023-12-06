using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_Backend.Entidades;
using static TPI_Backend.Entidades.Cliente;

namespace TPI_Backend.Datos.Interfaz
{
    public interface IClienteDao
    {
        public bool UpdateCliente(Cliente oCliente);
        public bool BorrarCliente(int numero);
        public bool CrearCliente(Cliente oCliente);
        List<Cliente> ObtenerClientes(DateTime fecha_desde, DateTime fecha_hasta);
        List<Cliente> ObtenerClientes();
        List<tipoDocumentoCliente> GetTiposDocumentos();

        public bool DeleteCliente(int idcliente);

        int ValidarTieneTicket(int idCliente);

        
    }
}
