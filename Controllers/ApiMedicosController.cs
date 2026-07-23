using CitasApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    [ApiController]
    [Route("api/medicos")]
    public class ApiMedicosController : ControllerBase
    {
        private readonly IMedicoRepository _repo;

        public ApiMedicosController(IMedicoRepository repo)
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
            var medico = _repo.ObtenerPorId(id);

            if (medico == null)
            {
                return NotFound(new
                {
                    mensaje = "No se encontró el médico"
                });
            }

            return Ok(medico);
        }
    }
}
