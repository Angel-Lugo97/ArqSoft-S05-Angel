using System.Text.Json;

namespace CitasApp.Data
{
    public static class DatosJson
    {
        private static readonly JsonSerializerOptions opciones = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public static List<T> Leer<T>(string archivo)
        {
            var ruta = Path.Combine(Directory.GetCurrentDirectory(), "Data", archivo);

            if (!File.Exists(ruta))
            {
                File.WriteAllText(ruta, "[]");
            }

            var json = File.ReadAllText(ruta);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(json, opciones) ?? new List<T>();
        }

        public static void Guardar<T>(string archivo, List<T> datos)
        {
            var ruta = Path.Combine(Directory.GetCurrentDirectory(), "Data", archivo);

            var json = JsonSerializer.Serialize(datos, opciones);

            File.WriteAllText(ruta, json);
        }
    }
}