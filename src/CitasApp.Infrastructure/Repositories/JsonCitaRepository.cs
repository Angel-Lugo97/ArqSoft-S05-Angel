using CitasApp.Interfaces;
using CitasApp.Models;
using System.Text.Json;

namespace CitasApp.Repositories
{
    public class JsonCitaRepository : ICitaRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public JsonCitaRepository()
        {
            _path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "Citas.json");
        }

        public List<Cita> ObtenerTodos()
        {
            if (!File.Exists(_path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                File.WriteAllText(_path, "[]");
            }

            var json = File.ReadAllText(_path);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Cita>();
            }

            var citasJson = JsonSerializer.Deserialize<List<CitaJson>>(json, _options) ?? new List<CitaJson>();

            return citasJson.Select(c => new Cita
            {
                Id = c.Id,
                PacienteId = c.PacienteId,
                MedicoId = c.MedicoId,
                Fecha = DateOnly.Parse(c.Fecha),
                Hora = TimeOnly.Parse(c.Hora),
                Motivo = c.Motivo,
                Estado = c.Estado
            }).ToList();
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId)
        {
            return ObtenerTodos()
                .Where(c => c.PacienteId == pacienteId)
                .ToList();
        }

        public void Agregar(Cita cita)
        {
            var citas = ObtenerTodos();

            cita.Id = citas.Any()
                ? citas.Max(c => c.Id) + 1
                : 1;

            if (string.IsNullOrWhiteSpace(cita.Estado))
            {
                cita.Estado = "Pendiente";
            }

            citas.Add(cita);
            Guardar(citas);
        }

        private void Guardar(List<Cita> citas)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

            var citasJson = citas.Select(c => new CitaJson
            {
                Id = c.Id,
                PacienteId = c.PacienteId,
                MedicoId = c.MedicoId,
                Fecha = c.Fecha.ToString("yyyy-MM-dd"),
                Hora = c.Hora.ToString("HH:mm:ss"),
                Motivo = c.Motivo,
                Estado = c.Estado
            }).ToList();

            var json = JsonSerializer.Serialize(citasJson, _options);
            File.WriteAllText(_path, json);
        }
    }
}
