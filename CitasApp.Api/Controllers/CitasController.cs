using CitasApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitasController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_citaService.ObtenerTodos());
        }

        [HttpGet("porpaciente/{pacienteId}")]
        public IActionResult PorPaciente(int pacienteId)
        {
            var citas = _citaService.ObtenerPorPaciente(pacienteId);

            if (citas.Count == 0)
            {
                return NotFound();
            }

            return Ok(citas);
        }

        [HttpPost("{id}/confirmar")]
        public IActionResult Confirmar(int id)
        {
            var confirmado = _citaService.Confirmar(id);

            if (!confirmado)
            {
                return NotFound(new
                {
                    mensaje = "No se encontró la cita"
                });
            }

            return Ok(new
            {
                mensaje = "Cita confirmada y notificaciones enviadas"
            });
        }
    }
}
