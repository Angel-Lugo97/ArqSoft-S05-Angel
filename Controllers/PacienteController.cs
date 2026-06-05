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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            var pacientes = Pacientes();

            paciente.Id = pacientes.Any() ? pacientes.Max(p => p.Id) + 1 : 1;

            pacientes.Add(paciente);

            DatosJson.Guardar("Pacientes.json", pacientes);

            return RedirectToAction(nameof(Index));
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