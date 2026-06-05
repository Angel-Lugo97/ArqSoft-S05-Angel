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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            var medicos = Medicos();

            medico.Id = medicos.Any() ? medicos.Max(m => m.Id) + 1 : 1;

            medicos.Add(medico);

            DatosJson.Guardar("Medicos.json", medicos);

            return RedirectToAction(nameof(Index));
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