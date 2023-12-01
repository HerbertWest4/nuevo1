using Microsoft.AspNetCore.Mvc;
using NesHer.Context;
using NesHer.Models;

namespace NesHer.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class ContenidoController : Controller
    {
        public readonly AplicacionContext aplicacionContext;
        public ContenidoController(AplicacionContext _aplicacionContext) {
           aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarContenidos")]
        public async Task<IActionResult> MostrarContenidos() {
            List<Contenido> contenidos = aplicacionContext.Contenido.OrderByDescending(contenidos=>contenidos.idContenido).ToList();
            return StatusCode(StatusCodes.Status200OK, contenidos);

        }
        [HttpPost]
        [Route("CrearContenidos")]
        public async Task<IActionResult> CrearContenidos([FromBody] Contenido contenido)  { 
            aplicacionContext.Contenido.Add(contenido);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarContenidos")]
        public async Task<IActionResult> EditarContenidos([FromBody] Contenido contenido) {
            aplicacionContext.Contenido.Update(contenido);
            aplicacionContext.SaveChanges ();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarContenidos/")]
        public async Task< IActionResult> EliminarContenidos(int id) {
            Contenido contenido = aplicacionContext.Contenido.Find(id);
            aplicacionContext.Contenido.Remove(contenido);
            aplicacionContext.SaveChanges () ;
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }


    }
}
