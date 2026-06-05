using CitasApp.Data;
using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Controllers
{
    public class CitaController : Controller
    {
        private List<Paciente> Pacientes()
        {
            return DatosJson.Leer<Paciente>("Pacientes.json");
        }

        private List<Medico> Medicos()
        {
            return DatosJson.Leer<Medico>("Medicos.json");
        }

        private List<Cita> Citas()
        {
            return DatosJson.Leer<Cita>("Citas.json");
        }

        public IActionResult Index()
        {
            ViewBag.Pacientes = Pacientes();
            ViewBag.Medicos = Medicos();

            return View(Citas());
        }

        public IActionResult Create()
        {
            ViewBag.Pacientes = Pacientes();
            ViewBag.Medicos = Medicos();

            return View(new Cita
            {
                Fecha = DateOnly.FromDateTime(DateTime.Today),
                Hora = new TimeOnly(9, 0, 0),
                Estado = "Pendiente"
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cita cita)
        {
            var citas = Citas();

            cita.Id = citas.Any() ? citas.Max(c => c.Id) + 1 : 1;

            citas.Add(cita);

            DatosJson.Guardar("Citas.json", citas);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            var citas = Citas().Where(c => c.PacienteId == pacienteId).ToList();

            ViewBag.Pacientes = Pacientes();
            ViewBag.Medicos = Medicos();

            return View(citas);
        }
    }
}