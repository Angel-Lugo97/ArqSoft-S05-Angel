using Microsoft.AspNetCore.Mvc;
using CitasApp.Models;
using CitasApp.Interfaces;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _repo;

        public MedicoController(IMedicoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.ObtenerTodos());
        }

        public IActionResult Detalle(int id)
        {
            var medico = _repo.ObtenerPorId(id);

            return medico == null
                ? NotFound()
                : View(medico);
        }

        public IActionResult Create()
        {
            return View(new Medico());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return View(medico);
            }

            _repo.Agregar(medico);
            return RedirectToAction(nameof(Index));
        }
    }
}
