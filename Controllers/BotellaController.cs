using Microsoft.AspNetCore.Mvc;
using NesHer.Context;
using NesHer.Models;

namespace NesHer.Controllers


{
    [ApiController]
    [Route("[controller]")]
    public class BotellaController : Controller
    {

        public readonly AplicacionContext aplicacionContext;
        public BotellaController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarBotellas")]
        public async Task<IActionResult> MostrarBotellas()
        {
            List<Botella> botellas = aplicacionContext.Botella.OrderByDescending(botellas => botellas.idBotella).ToList();
            return StatusCode(StatusCodes.Status200OK, botellas);

        }
        [HttpPost]
        [Route("CrearBotellas")]
        public async Task<IActionResult> CrearBotellas([FromBody] Botella botella)
        {
            aplicacionContext.Botella.Add(botella);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarBotellas")]
        public async Task<IActionResult> EditarBotellas([FromBody] Botella botella)
        {
            aplicacionContext.Botella.Update(botella);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarBotellas/")]
        public async Task<IActionResult> EliminarBotellas(int id)
        {
            Botella botella = aplicacionContext.Botella.Find(id);
            aplicacionContext.Botella.Remove(botella);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }
    }
}
