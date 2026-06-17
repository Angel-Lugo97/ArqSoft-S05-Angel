using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Application.Services
{
    public class CitaService
    {
        private readonly ICitaRepository _citaRepository;

        public CitaService(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public List<Cita> ObtenerTodos()
        {
            return _citaRepository.ObtenerTodos();
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId)
        {
            return _citaRepository.ObtenerPorPaciente(pacienteId);
        }

        public void Agregar(Cita cita)
        {
            _citaRepository.Agregar(cita);
        }
    }
}
