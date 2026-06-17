using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Application.Services
{
    public class MedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public List<Medico> ObtenerTodos()
        {
            return _medicoRepository.ObtenerTodos();
        }

        public Medico? ObtenerPorId(int id)
        {
            return _medicoRepository.ObtenerPorId(id);
        }

        public void Agregar(Medico medico)
        {
            _medicoRepository.Agregar(medico);
        }
    }
}
