using CitasApp.Interfaces;
using CitasApp.Models;
using System.Text.Json;

namespace CitasApp.Repositories
{
    public class JsonMedicoRepository : IMedicoRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public JsonMedicoRepository()
        {
            _path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "Medicos.json");
        }

        public List<Medico> ObtenerTodos()
        {
            if (!File.Exists(_path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                File.WriteAllText(_path, "[]");
            }

            var json = File.ReadAllText(_path);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Medico>();
            }

            return JsonSerializer.Deserialize<List<Medico>>(json, _options) ?? new List<Medico>();
        }

        public Medico? ObtenerPorId(int id)
        {
            return ObtenerTodos().FirstOrDefault(m => m.Id == id);
        }

        public void Agregar(Medico medico)
        {
            var medicos = ObtenerTodos();

            medico.Id = medicos.Any()
                ? medicos.Max(m => m.Id) + 1
                : 1;

            medicos.Add(medico);
            Guardar(medicos);
        }

        private void Guardar(List<Medico> medicos)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

            var json = JsonSerializer.Serialize(medicos, _options);
            File.WriteAllText(_path, json);
        }
    }
}
