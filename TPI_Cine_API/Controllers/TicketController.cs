using Microsoft.AspNetCore.Mvc;
using TPI_Backend.Datos.Implementacion;
using TPI_Backend.Entidades;
using TPI_Backend.Fachada.Implementacion;
using TPI_Backend.Fachada.Interfaz;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TPI_Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private IAplicacion app;
        public TicketController()
        {
            app = new Aplicacion();
        }

        // GET: api/<PresupuestoController>
        [HttpGet("/clientes")]
        public IActionResult GetClientes()
        {
            List<Cliente> lst = null;
            try
            {
                lst = app.GetClientes();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno!!! Intente luego...");
            }

        }

        //GET Tickets
        [HttpGet("/Tickets")]
        public IActionResult GetTickets()
        {
            List<Ticket> listaTickets = new List<Ticket>();
            try
            {
                listaTickets = app.GetTickets();
                return Ok(listaTickets);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }


        //GET Tickets con fecha
        [HttpGet("/TicketsConParam")]
        public IActionResult GetTicketsConFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Ticket> listaTickets = new List<Ticket>();
            try
            {
                listaTickets = app.GetTicketsConFecha(fechaDesde, fechaHasta);
                return Ok(listaTickets);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }

        // GET Descuentos
        [HttpGet("/Descuentos")]
        public IActionResult GetDescuentos(int numero_semana)
        {
            Dictionary<int, int> descuento = new Dictionary<int, int>();

            try
            {
                descuento = app.GetDescuento(numero_semana);
                return Ok(descuento);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }

        }

        // GET Butacas
        [HttpGet("/Butacas")]
        public IActionResult GetButacas(int id_funcion)
        {
            List<Butaca> lButacas = new List<Butaca>();

            try
            {
                lButacas = app.GetButacas(id_funcion);
                return Ok(lButacas);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }

        // POST api/<TicketController>
        [HttpPost("/ticket")]
        public IActionResult PostTicket(Ticket oTicket)
        {
            try
            {
                if (oTicket != null)
                {
                    bool result = app.SaveTicket(oTicket);
                    if (result)
                    {
                        return Ok(result);
                    }
                    else
                        return BadRequest("No se pudo guardar el presupuesto!!!");
                }
                else
                    return BadRequest("Ticket inválido!!!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno!!! Intente luego...");
            }
        }

        // PUR api/<TicketController>
        [HttpPut("/ticket")]
        public IActionResult PutTicket(Ticket oTicket)
        {
            try
            {
                if (oTicket != null)
                {
                    bool result = app.UpdateTicket(oTicket);
                    if (result)
                    {
                        return Ok(result);
                    }
                    else
                        return BadRequest("No se pudo actualizar el presupuesto!!!");
                }
                else
                    return BadRequest("Ticket inválido!!!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno!!! Intente luego...");
            }
        }

        [HttpDelete("DeleteTicket")]
        public IActionResult DeleteTicket(int idTicket)
        {
            try
            {
                var result = app.BorrarTicket(idTicket);
                if (result == null)
                {
                    return StatusCode(500, " Se produjo un error al dar de baja un ticket");
                }
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


        //public IActionResult PostTicket(Ticket oTicket)
        //{
        //    try
        //    {
        //        if (oTicket == null)
        //            return BadRequest("Ticket inválido!!!");
        //        if (app.SaveTicket(oTicket))
        //            return Ok(oTicket);
        //        else
        //            return BadRequest("No se pudo guardar el presupuesto!!!");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error interno!!! Intente luego...");
        //    }

        //}



        //// GET: api/<TicketController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<TicketController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<TicketController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<TicketController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TicketController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
