using CitasApp.Models;
using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Controllers
{
    public class MedicoController : Controller
    {
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
        // Lista con filtro opcional por género

        public IActionResult Index() => View(_medicos);



        // Detalle de un item

        public IActionResult Detalle(int id)
        {
            var medico = _medicos.FirstOrDefault(m => m.Id == id);
            return medico == null ? NotFound() : View(medico);
        }
    }

}