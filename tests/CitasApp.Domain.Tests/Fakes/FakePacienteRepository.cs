using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Domain.Tests.Fakes;

public sealed class FakePacienteRepository : IPacienteRepository
{
    public List<Paciente> Pacientes { get; } = new();

    public List<Paciente> ObtenerTodos()
    {
        return Pacientes.ToList();
    }

    public Paciente? ObtenerPorId(int id)
    {
        return Pacientes.FirstOrDefault(paciente => paciente.Id == id);
    }

    public void Agregar(Paciente paciente)
    {
        Pacientes.Add(paciente);
    }
}
