using CitasApp.Models;
using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace Citas_App.Controllers
{
    public class CitaController : Controller
    {
        private static List<Paciente> _pacientes = new()
        {
            new Paciente
            {
                Id = 1,
                Nombre = "Ana",
                Apellido = "Garcia",
                Email = "ana.garcia@gmail.com",
                Telefono = "555-0001"
            },
            new Paciente
            {
                Id = 2,
                Nombre = "Luis",
                Apellido = "Martinez",
                Email = "luis.martinez@gmail.com",
                Telefono = "555-0002"
            },
            new Paciente
            {
                Id = 3,
                Nombre = "Maria",
                Apellido = "Lopez",
                Email = "maria.lopez@gmail.com",
                Telefono = "555-0003"
            }
        };
        private static List<Medico> _medicos = new()
        {
            new Medico
            {
                Id = 1,
                Nombre = "Dr. Carlos",
                Apellido = "Reyes",
                Especialidad="Medicina General",
                NumeroLicencia = "MG-10421"
            },
            new Medico
            {
                Id = 2,
                Nombre = "Dra. Patricia",
                Apellido = "Vega",
                Especialidad="Pediatria",
                NumeroLicencia = "PG-20835"
            },
            new Medico
            {
                Id = 3,
                Nombre = "Dr. Roberto",
                Apellido = "Sánchez",
                Especialidad="Cardiología",
                NumeroLicencia = "CA-30117"
            },
        };
        private static List<Cita> _citas = new()
        {
            new Cita
            {
                Id=1,
                PacienteId=1,
                MedicoId=1,
                Fecha=new  DateOnly(2026, 1, 6),
                Hora=new TimeOnly(9, 0, 0),
                Motivo="Consulta general",
                Estado="Confirmada"
            },

            new Cita
            {
                Id=2,
                PacienteId=2,
                MedicoId=2,
                Fecha=new DateOnly(2026, 1, 6),
                Hora=new TimeOnly(10, 0, 0),
                Motivo="Revisión de resultados",
                Estado="Pendiente"
            },
            new Cita
            {
                Id=3,
                PacienteId=3,
                MedicoId=1,
                Fecha=new DateOnly(2026, 1, 6),
                Hora=new TimeOnly(11, 0, 0),
                Motivo="Primera consulta",
                Estado="Pendiente"
            },
        };
        // Lista con filtro opcional por género

        public IActionResult Index()
        {

            ViewBag.Pacientes = _pacientes;
            ViewBag.Medicos = _medicos;

            return View(_citas);
        }


        // Detalle de un item

        public IActionResult PorPaciente(int pacienteId)
        {
            var citas = _citas.Where(c => c.PacienteId == pacienteId).ToList();
            ViewBag.Pacientes = _pacientes;
            ViewBag.Medicos = _medicos;
            return View(citas);
        }
    }
}