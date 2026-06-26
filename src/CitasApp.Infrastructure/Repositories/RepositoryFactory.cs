using CitasApp.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace CitasApp.Repositories
{
    public static class RepositoryFactory
    {
        public static IPacienteRepository CrearPacienteRepository(string entorno, IWebHostEnvironment env)
        {
            _ = env;

            return entorno switch
            {
                "Production" => new MemoriaPacienteRepository(),
                _ => new JsonPacienteRepository()
            };
        }

        public static IMedicoRepository CrearMedicoRepository(string entorno, IWebHostEnvironment env)
        {
            _ = entorno;
            _ = env;

            return new JsonMedicoRepository();
        }

        public static ICitaRepository CrearCitaRepository(string entorno, IWebHostEnvironment env)
        {
            _ = entorno;
            _ = env;

            return new JsonCitaRepository();
        }
    }
}
