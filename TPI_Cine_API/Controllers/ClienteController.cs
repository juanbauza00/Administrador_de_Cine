using Microsoft.AspNetCore.Mvc;
using TPI_Backend.Entidades;
using TPI_Backend.Fachada.Implementacion;
using TPI_Backend.Fachada.Interfaz;
using static TPI_Backend.Entidades.Cliente;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TPI_Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IAplicacion app;

        public ClienteController()
        {
            app = new Aplicacion();
        }

        // GET: api/<ClienteController>
        [HttpGet("tiposDocumentos")]
        public IActionResult Get()
        {
            List<tipoDocumentoCliente> listaTiposDocumentos = new List<tipoDocumentoCliente>();
            try
            {
                listaTiposDocumentos = app.GetTiposDocumentos();
                return Ok(listaTiposDocumentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        //// GET api/<ClienteController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // post api/<clientecontroller>
        [HttpPost]
        public IActionResult postCliente(Cliente nuevoCliente)

        {
            try
            {
                if (nuevoCliente == null)
                {
                    return BadRequest("Cliente invalido (fue null)");

                }
                bool result = app.GuardarCliente(nuevoCliente);

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("Clientes")]
        public IActionResult GetClientes(DateTime fecha_desde, DateTime fecha_hasta)
        {
            List<Cliente> lClientes = new List<Cliente>();
            try
            {
                lClientes = app.GetClientes(fecha_desde, fecha_hasta);
                return Ok(lClientes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }

        }

        [HttpGet("Clientes_no_param")]
        public IActionResult GetClientesNoParam()
        {
            List<Cliente> lClientes = new List<Cliente>();
            try
            {
                lClientes = app.GetClientes();
                return Ok(lClientes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        // PUT api/<ClienteController>/5
        [HttpPut("Cliente")]
        public IActionResult Put(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Cliente invalido (fue null)");
                }
                bool result = app.ActualizarCliente(cliente);

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }



        [HttpDelete("DeleteCliente")]
        public IActionResult DeleteCliente(int idcliente)
        {
            try
            {
                var result = app.BorrarCliente(idcliente);
                if (result == null)
                {
                    return StatusCode(500, " Se produjo un error al dar de baja un cliente");
                }
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet("/TieneTicket")]
        public IActionResult tieneCliente(int idCliente)
        {
            {
                try
                {
                    var result = app.ValidarTieneTicket(idCliente);
                    if (result == null)
                    {
                        return StatusCode(500, " Se produjo un error al dar de baja un cliente");
                    }
                    return Ok(result);

                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
        }

        
    }
}
