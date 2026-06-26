using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Observers
{
    public class EmailObserver : ICitaObserver
    {
        public void Notificar(Cita cita)
        {
            Console.WriteLine($"Email enviado: la cita #{cita.Id} fue confirmada para el paciente #{cita.PacienteId}.");
        }
    }
}
