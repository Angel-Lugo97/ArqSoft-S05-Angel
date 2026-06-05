using CitasApp.Data;
using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Controllers
{
    public class PacienteController : Controller
    {
        private List<Paciente> Pacientes()
        {
            return DatosJson.Leer<Paciente>("Pacientes.json");
        }

        public IActionResult Index()
        {
            return View(Pacientes());
        }

        public IActionResult Detalle(int id)
        {
            var paciente = Pacientes().FirstOrDefault(p => p.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }
    }
}