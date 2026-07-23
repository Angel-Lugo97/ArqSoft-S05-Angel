using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Repositories
{
    public class MemoriaPacienteRepository : IPacienteRepository
    {
        private static readonly List<Paciente> Pacientes = new();
        private static int _siguienteId = 1;

        public List<Paciente> ObtenerTodos()
        {
            return Pacientes;
        }

        public Paciente? ObtenerPorId(int id)
        {
            return Pacientes.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Paciente paciente)
        {
            paciente.Id = _siguienteId++;
            Pacientes.Add(paciente);
        }
    }
}
