using CitasApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly CitaService _citaService;
        private readonly PacienteService _pacienteService;
        private readonly MedicoService _medicoService;

        public CitasController(
            CitaService citaService,
            PacienteService pacienteService,
            MedicoService medicoService)
        {
            _citaService = citaService;
            _pacienteService = pacienteService;
            _medicoService = medicoService;
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
