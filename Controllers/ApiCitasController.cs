using CitasApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    [ApiController]
    [Route("api/citas")]
    public class ApiCitasController : ControllerBase
    {
        private readonly ICitaRepository _repo;

        public ApiCitasController(ICitaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult ListarTodas()
        {
            return Ok(_repo.ObtenerTodos());
        }

        [HttpGet("por-paciente/{pacienteId:int}")]
        [HttpGet("porpaciente/{pacienteId:int}")]
        public IActionResult BuscarPorPaciente(int pacienteId)
        {
            var citas = _repo.ObtenerPorPaciente(pacienteId);

            if (citas.Count == 0)
            {
                return NotFound(new
                {
                    mensaje = "No se encontraron citas para ese paciente"
                });
            }

            return Ok(citas);
        }
    }
}
