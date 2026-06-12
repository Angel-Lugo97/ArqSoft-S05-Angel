using CitasApp.Interfaces;
using CitasApp.Models;
using System.Text.Json;

namespace CitasApp.Repositories
{
    public class JsonPacienteRepository : IPacienteRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public JsonPacienteRepository()
        {
            _path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "Pacientes.json");
        }

        public List<Paciente> ObtenerTodos()
        {
            if (!File.Exists(_path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                File.WriteAllText(_path, "[]");
            }

            var json = File.ReadAllText(_path);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Paciente>();
            }

            return JsonSerializer.Deserialize<List<Paciente>>(json, _options) ?? new List<Paciente>();
        }

        public Paciente? ObtenerPorId(int id)
        {
            return ObtenerTodos().FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Paciente paciente)
        {
            var pacientes = ObtenerTodos();

            paciente.Id = pacientes.Any()
                ? pacientes.Max(p => p.Id) + 1
                : 1;

            pacientes.Add(paciente);
            Guardar(pacientes);
        }

        private void Guardar(List<Paciente> pacientes)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

            var json = JsonSerializer.Serialize(pacientes, _options);
            File.WriteAllText(_path, json);
        }
    }
}
