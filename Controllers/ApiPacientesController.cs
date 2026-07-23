using CitasApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class ApiPacientesController : ControllerBase
    {
        private readonly IPacienteRepository _repo;

        public ApiPacientesController(IPacienteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_repo.ObtenerTodos());
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscarPorId(int id)
        {
            var paciente = _repo.ObtenerPorId(id);

            if (paciente == null)
            {
                return NotFound(new
                {
                    mensaje = "No se encontró el paciente"
                });
            }

            return Ok(paciente);
        }
    }
}
