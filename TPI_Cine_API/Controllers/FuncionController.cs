using Microsoft.AspNetCore.Mvc;
using TPI_Backend.Entidades;
using TPI_Backend.Fachada.Implementacion;
using TPI_Backend.Fachada.Interfaz;
using static TPI_Backend.Entidades.Funcion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TPI_Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private IAplicacion app;

        public FuncionController()
        {
            app = new Aplicacion();
        }



        // GET Peliculas
        [HttpGet("Peliculas")]
        public IActionResult GetPeliculas()
        {
            List<Pelicula> list = new List<Pelicula>();
            try
            {
                list = app.ObtenerPeliculas();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }

        }

        //GET Salas
        [HttpGet("Tipos_salas")]
        public IActionResult GetSalas()
        {
            List<SalaCine> salas = new List<SalaCine>();
            try
            {
                salas = app.ObtenerSalas();
                return Ok(salas);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }

        //GET Formatos Funciones
        [HttpGet("Formatos_funciones")]
        public IActionResult GetFormatosFunciones()
        {
            List<FormatoFuncion> listaFormatoFuncion = new List<FormatoFuncion>();
            try
            {
                listaFormatoFuncion = app.ObtenerFormatosFunciones();
                return Ok(listaFormatoFuncion);

            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }


        // get Funciones
        [HttpGet("Funciones")]
        public IActionResult GetFunciones(DateTime fecha_desde, DateTime fecha_hasta)
        {
            List<Funcion> listaFunciones = new List<Funcion>();
            
            try
            {
                listaFunciones = app.GetFunciones(fecha_desde, fecha_hasta);
                return Ok(listaFunciones);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }

        // POST api/<FuncionController>
        [HttpPost]
        public IActionResult PostFuncion(Funcion nuevaFuncion)
        {
            try
            {
                if (nuevaFuncion == null)
                {
                    return BadRequest("Cliente invalido (fue null)");

                }
                bool result = app.GuardarFuncion(nuevaFuncion);

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpDelete("DeleteFuncion")]
        public IActionResult DeleteFuncion(int idFuncion)
        {
            try
            {
                var result = app.BorrarFuncion(idFuncion);
                if (result == null)
                {
                    return StatusCode(500, " Se produjo un error al dar de baja una funcion");
                }
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpGet("/TieneButaca")]
        public IActionResult tieneButaca(int idFuncion)
        {
            {
                try
                {
                    var result = app.ValidarTieneButaca(idFuncion);
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

        [HttpPut("PutFuncion")]
        public IActionResult putFuncion(Funcion funcion) {
            try
            {
                var result = app.ActualizarFuncion(funcion);
                if (result == null)
                {
                    return StatusCode(500, "Error al actualiar la funcion");
                }
                return Ok(result);
            }
            catch {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("FuncionesNoParam")]
        public IActionResult GetFunciones()
        {
            List<Funcion> listaFunciones = new List<Funcion>();

            try
            {
                listaFunciones = app.GetFunciones();
                return Ok(listaFunciones);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("FuncionesIdFuncionButaca")]
        public IActionResult GetFuncionesFB(int idFuncionButaca)
        {
            Funcion funcion;

            try
            {
                funcion = app.GetFuncionesFB(idFuncionButaca);
                return Ok(funcion);
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }


    }
}
