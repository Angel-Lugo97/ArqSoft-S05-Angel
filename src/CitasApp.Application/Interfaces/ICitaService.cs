using CitasApp.Models;

namespace CitasApp.Application.Interfaces
{
    public interface ICitaService
    {
        List<Cita> ObtenerTodos();

        List<Cita> ObtenerPorPaciente(int pacienteId);

        void Agregar(Cita cita);

        bool Confirmar(int citaId);
    }
}
