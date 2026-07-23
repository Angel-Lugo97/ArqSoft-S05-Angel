using CitasApp.Interfaces;
using CitasApp.Models;

namespace CitasApp.Repositories
{
    public class CsvMedicoRepository : IMedicoRepository
    {
        private readonly string _filePath;

        public CsvMedicoRepository(string filePath)
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
                File.WriteAllText(_filePath, "Id,Nombre,Apellido,Especialidad,NumeroLicencia\n");
            }
        }

        private List<Medico> LeerTodos()
        {
            var lista = new List<Medico>();

            foreach (var linea in File.ReadAllLines(_filePath).Skip(1))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;

                var p = linea.Split(',');
                if (p.Length < 5) continue;

                lista.Add(new Medico
                {
                    Id = int.Parse(p[0]),
                    Nombre = p[1],
                    Apellido = p[2],
                    Especialidad = p[3],
                    NumeroLicencia = p[4]
                });
            }

            return lista;
        }

        private void EscribirTodos(List<Medico> medicos)
        {
            var lineas = new List<string>
            {
                "Id,Nombre,Apellido,Especialidad,NumeroLicencia"
            };

            foreach (var m in medicos)
            {
                lineas.Add(
                    $"{m.Id}," +
                    $"{Limpiar(m.Nombre)}," +
                    $"{Limpiar(m.Apellido)}," +
                    $"{Limpiar(m.Especialidad)}," +
                    $"{Limpiar(m.NumeroLicencia)}"
                );
            }

            File.WriteAllLines(_filePath, lineas);
        }

        private static string Limpiar(string texto)
        {
            return (texto ?? string.Empty).Replace(",", ";");
        }

        public List<Medico> ObtenerTodos()
        {
            return LeerTodos();
        }

        public Medico? ObtenerPorId(int id)
        {
            return LeerTodos().FirstOrDefault(m => m.Id == id);
        }

        public void Agregar(Medico medico)
        {
            var medicos = LeerTodos();

            medico.Id = medicos.Any()
                ? medicos.Max(m => m.Id) + 1
                : 1;

            medicos.Add(medico);
            EscribirTodos(medicos);
        }
    }
}
