using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Observers
{
    public class SmsObserver : ICitaObserver
    {
        public void Notificar(Cita cita)
        {
            Console.WriteLine($"SMS enviado: la cita #{cita.Id} fue confirmada para el paciente #{cita.PacienteId}.");
        }
    }
}
