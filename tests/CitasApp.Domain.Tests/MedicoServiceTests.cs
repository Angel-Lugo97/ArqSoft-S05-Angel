using CitasApp.Application.Services;
using CitasApp.Domain.Tests.Fakes;
using CitasApp.Models;
using Xunit;

namespace CitasApp.Domain.Tests;

public class MedicoServiceTests
{
    [Fact]
    public void Agregar_ConMedicoValido_GuardaMedicoEnRepositorio()
    {
        // Arrange
        var repositorio = new FakeMedicoRepository();
        var servicio = new MedicoService(repositorio);

        var medico = new Medico
        {
            Id = 2,
            Nombre = "Carlos",
            Apellido = "López",
            Especialidad = "Cardiología",
            NumeroLicencia = "MED-2026-001"
        };

        // Act
        servicio.Agregar(medico);

        // Assert
        Assert.Single(repositorio.Medicos);
        Assert.Equal(2, repositorio.Medicos[0].Id);
        Assert.Equal("Cardiología", repositorio.Medicos[0].Especialidad);
    }
}
