using CitasApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteService _service;

        public PacientesController(PacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _service.ObtenerPorId(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }
    }
}
