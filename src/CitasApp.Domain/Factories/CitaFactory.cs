using CitasApp.Models;

namespace CitasApp.Factories;

public class CitaFactory
{
    public Cita Construir(
        int pacienteId,
        int medicoId,
        DateOnly fecha,
        TimeOnly hora,
        string motivo)
    {
        return new Cita
        {
            PacienteId = pacienteId,
            MedicoId = medicoId,
            Fecha = fecha,
            Hora = hora,
            Motivo = motivo,
            Estado = "Pendiente"
        };
    }
}
