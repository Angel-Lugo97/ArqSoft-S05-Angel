using Microsoft.AspNetCore.Mvc;
using CitasApp.Models;
using CitasApp.Interfaces;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaRepository _citaRepo;
        private readonly IPacienteRepository _pacienteRepo;
        private readonly IMedicoRepository _medicoRepo;

        public CitaController(
            ICitaRepository citaRepo,
            IPacienteRepository pacienteRepo,
            IMedicoRepository medicoRepo)
        {
            _citaRepo = citaRepo;
            _pacienteRepo = pacienteRepo;
            _medicoRepo = medicoRepo;
        }

        public IActionResult Index()
        {
            CargarPacientesYMedicos();
            return View(_citaRepo.ObtenerTodos());
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            CargarPacientesYMedicos();
            return View(_citaRepo.ObtenerPorPaciente(pacienteId));
        }

        public IActionResult Create()
        {
            CargarPacientesYMedicos();

            return View(new Cita
            {
                Fecha = DateOnly.FromDateTime(DateTime.Today),
                Hora = new TimeOnly(9, 0),
                Estado = "Pendiente"
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cita cita)
        {
            if (!ModelState.IsValid)
            {
                CargarPacientesYMedicos();
                return View(cita);
            }

            _citaRepo.Agregar(cita);
            return RedirectToAction(nameof(Index));
        }

        private void CargarPacientesYMedicos()
        {
            ViewBag.Pacientes = _pacienteRepo.ObtenerTodos();
            ViewBag.Medicos = _medicoRepo.ObtenerTodos();
        }
    }
}
