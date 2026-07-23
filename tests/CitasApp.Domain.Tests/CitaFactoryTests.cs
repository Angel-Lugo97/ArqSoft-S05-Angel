using CitasApp.Factories;

namespace CitasApp.Domain.Tests;

public class CitaFactoryTests
{
    [Fact]
    public void Construir_ConDatosValidos_CreaCitaConEstadoPendiente()
    {
        // Arrange
        var factory = new CitaFactory();

        // Act
        var cita = factory.Construir(
            pacienteId: 1,
            medicoId: 2,
            fecha: new DateOnly(2026, 7, 20),
            hora: new TimeOnly(10, 0),
            motivo: "Consulta"
        );

        // Assert
        Assert.Equal("Pendiente", cita.Estado);
        Assert.Equal(1, cita.PacienteId);
    }
}
