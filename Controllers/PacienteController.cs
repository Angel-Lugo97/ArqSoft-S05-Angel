using CitasApp.Models;
using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace Citas_App.Controllers
{
    public class PacienteController : Controller
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

        // Lista con filtro opcional por género

        public IActionResult Index() => View(_pacientes);



        // Detalle de un item

        public IActionResult Detalle(int id)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
            return paciente == null ? NotFound() : View(paciente);
        }
    }
}