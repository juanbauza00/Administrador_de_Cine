using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Backend.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public tipoDocumentoCliente TipoDocumento { get; set; }
        public int Documento { get; set; }

        public Cliente()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Documento = 0;
            IdCliente = 0;
        }

        public Cliente(int id, string nombre, string apellido, int doc, tipoDocumentoCliente tipoDoc)
        {
            IdCliente = id;
            Nombre = nombre;
            Apellido = apellido;
            Documento = doc;
            TipoDocumento = tipoDoc;
        }

        public enum tipoDocumentoCliente
        {
            Dni = 1,
            Pasaporte = 2,
            CedulaIdentidad = 3,
            LicenciaConducir = 4,
            TarjetaIdentificacion = 5,
        }

        public override string ToString()
        {
            return Apellido + " " + Nombre;
        }
    }
}
