using CitasApp.Application.Services;
using CitasApp.Domain.Tests.Fakes;
using CitasApp.Models;
using Xunit;

namespace CitasApp.Domain.Tests;

public class PacienteServiceTests
{
    [Fact]
    public void ObtenerPorId_ConPacienteExistente_RegresaPacienteCorrecto()
    {
        // Arrange
        var repositorio = new FakePacienteRepository();

        repositorio.Pacientes.Add(new Paciente
        {
            Id = 1,
            Nombre = "Ana",
            Apellido = "Martínez",
            Email = "ana@example.com",
            Telefono = "9991234567"
        });

        var servicio = new PacienteService(repositorio);

        // Act
        var paciente = servicio.ObtenerPorId(1);

        // Assert
        Assert.NotNull(paciente);
        Assert.Equal(1, paciente.Id);
        Assert.Equal("NombreIncorrecto", paciente.Nombre);
    }
}
