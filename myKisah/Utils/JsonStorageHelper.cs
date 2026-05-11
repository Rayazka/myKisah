using System.Text.Json;
using System.Text.Json.Serialization;

namespace myKisah.Utils
{
    public class JsonStorageHelper
    {
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public IEnumerable<T> ReadJson<T>(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path tidak boleh kosong.");

            var directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "[]");

            var json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
        }

        public void WriteJson<T>(string filePath, IEnumerable<T> data)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path tidak boleh kosong.");

            var directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            var json = JsonSerializer.Serialize(data, _options);

            File.WriteAllText(filePath, json);
        }
    }
}