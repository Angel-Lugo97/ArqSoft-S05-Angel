using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Application.Services
{
    public class CitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly List<ICitaObserver> _observers;

        public CitaService(ICitaRepository citaRepository, IEnumerable<ICitaObserver> observers)
        {
            _citaRepository = citaRepository;
            _observers = observers.ToList();
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

        public bool Confirmar(int citaId)
        {
            var cita = _citaRepository.ObtenerTodos()
                .FirstOrDefault(c => c.Id == citaId);

            if (cita == null)
            {
                return false;
            }

            cita.Estado = "Confirmada";

            _citaRepository.Actualizar(cita);

            NotificarObservers(cita);

            return true;
        }

        private void NotificarObservers(Cita cita)
        {
            foreach (var observer in _observers)
            {
                observer.Notificar(cita);
            }
        }
    }
}
