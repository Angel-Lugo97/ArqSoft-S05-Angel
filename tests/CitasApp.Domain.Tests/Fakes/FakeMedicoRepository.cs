using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Domain.Tests.Fakes;

public sealed class FakeMedicoRepository : IMedicoRepository
{
    public List<Medico> Medicos { get; } = new();

    public List<Medico> ObtenerTodos()
    {
        return Medicos.ToList();
    }

    public Medico? ObtenerPorId(int id)
    {
        return Medicos.FirstOrDefault(medico => medico.Id == id);
    }

    public void Agregar(Medico medico)
    {
        Medicos.Add(medico);
    }
}
