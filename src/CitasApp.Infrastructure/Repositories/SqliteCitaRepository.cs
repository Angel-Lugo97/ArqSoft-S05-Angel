using CitasApp.Interfaces;
using CitasApp.Models;
using Microsoft.Data.Sqlite;

namespace CitasApp.Repositories
{
    public class SqliteCitaRepository : ICitaRepository
    {
        private readonly string _connectionString;

        public SqliteCitaRepository(string dbPath)
        {
            _connectionString = $"Data Source={dbPath}";
            InicializarTabla();
        }

        private void InicializarTabla()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Citas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PacienteId INTEGER NOT NULL,
                    MedicoId INTEGER NOT NULL,
                    Fecha TEXT NOT NULL,
                    Hora TEXT NOT NULL,
                    Motivo TEXT,
                    Estado TEXT NOT NULL DEFAULT 'Pendiente'
                );";
            cmd.ExecuteNonQuery();
        }

        private static Cita LeerFila(SqliteDataReader r)
        {
            return new Cita
            {
                Id = r.GetInt32(0),
                PacienteId = r.GetInt32(1),
                MedicoId = r.GetInt32(2),
                Fecha = DateOnly.ParseExact(r.GetString(3), "yyyy-MM-dd"),
                Hora = TimeOnly.ParseExact(r.GetString(4), "HH:mm"),
                Motivo = r.IsDBNull(5) ? string.Empty : r.GetString(5),
                Estado = r.IsDBNull(6) ? "Pendiente" : r.GetString(6)
            };
        }

        public List<Cita> ObtenerTodos()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, PacienteId, MedicoId, Fecha, Hora, Motivo, Estado FROM Citas;";

            var lista = new List<Cita>();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                lista.Add(LeerFila(r));
            }

            return lista;
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, PacienteId, MedicoId, Fecha, Hora, Motivo, Estado FROM Citas WHERE PacienteId = $pacienteId;";
            cmd.Parameters.AddWithValue("$pacienteId", pacienteId);

            var lista = new List<Cita>();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                lista.Add(LeerFila(r));
            }

            return lista;
        }

        public void Agregar(Cita cita)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Citas (PacienteId, MedicoId, Fecha, Hora, Motivo, Estado)
                VALUES ($pacienteId, $medicoId, $fecha, $hora, $motivo, $estado);";

            cmd.Parameters.AddWithValue("$pacienteId", cita.PacienteId);
            cmd.Parameters.AddWithValue("$medicoId", cita.MedicoId);
            cmd.Parameters.AddWithValue("$fecha", cita.Fecha.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("$hora", cita.Hora.ToString("HH:mm"));
            cmd.Parameters.AddWithValue("$motivo", cita.Motivo ?? string.Empty);
            cmd.Parameters.AddWithValue("$estado", string.IsNullOrWhiteSpace(cita.Estado) ? "Pendiente" : cita.Estado);

            cmd.ExecuteNonQuery();
        }
    }
}
