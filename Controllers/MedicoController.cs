using CitasApp.Data;
using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citas_App.Controllers
{
    public class MedicoController : Controller
    {
        private List<Medico> Medicos()
        {
            return DatosJson.Leer<Medico>("Medicos.json");
        }

        public IActionResult Index()
        {
            return View(Medicos());
        }

        public IActionResult Detalle(int id)
        {
            var medico = Medicos().FirstOrDefault(m => m.Id == id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }
    }
}