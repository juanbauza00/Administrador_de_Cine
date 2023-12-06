using Microsoft.AspNetCore.Mvc;
using TPI_Backend.Entidades;
using TPI_Backend.Fachada.Implementacion;
using TPI_Backend.Fachada.Interfaz;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TPI_Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {

        private IAplicacion app;
        public GerenteController() {
            app = new Aplicacion();
        }

        //GET: api/testAPI
        [HttpGet("/gerentes/testAPI")]
        public IActionResult testAPI() {
            return Ok(1);
        }
        // GET: api/<GerenteController>
        [HttpGet("/gerentes")]
        public IActionResult Get()
        {
            List<Gerente> gerenteList = new List<Gerente>();
            try
            {
                gerenteList = app.GetGerentes();
                return Ok(gerenteList);
            }
            catch (Exception ex){
                return StatusCode(500, "Error interno, intente nuevamente mas tarde");
                
            }
        }
        //get validarPassword
        [HttpGet("/gerentes/validar")]
        public IActionResult validarPassword(string email, string password) {
            try {
                int success = app.validarPassword(email,password);
                return Ok(success);
            }
            catch (Exception ex){
                return StatusCode(500, "Error interno, intente nuevamente mas tarde");
            }
        }

        [HttpGet("/gerentes/test")]
        public IActionResult myHandler(string query) {
            return Ok(query);
        }

        // GET api/<GerenteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GerenteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GerenteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GerenteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
