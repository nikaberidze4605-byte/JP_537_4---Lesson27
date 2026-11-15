using Lesson24.Enums;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Lesson24.Extentions
{
    internal static class JSONFileHelper<T>
    {
        private static readonly string[] _paths = new string[]
        {
            @"C:\Users\student\Desktop\Hotels\Hotels.json",
            @"C:\Users\student\Desktop\Hotels\Rooms.json",
            @"C:\Users\student\Desktop\Hotels\Users.json",
        };

        private static JsonSerializerOptions _options { get; set; } = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        public async static Task WriteInJson(FILE_TYPES fileTypes, T entity)
        {
            string sreializde = JsonSerializer.Serialize(entity, _options);
            await File.WriteAllTextAsync(_paths[Convert.ToInt32(fileTypes)], sreializde);


        }

        public async static Task WriteInJson(FILE_TYPES fileTypes, List<T> values)
        {
            string serializde = JsonSerializer.Serialize(values, _options);
            await File.WriteAllTextAsync(_paths[Convert.ToInt32(fileTypes)], serializde);
        }

        public async static Task<List<T>?> ReadFromeJson(FILE_TYPES fileTypes)
        {
            string data = await File.ReadAllTextAsync(_paths[Convert.ToInt32(fileTypes)]);
            List<T>? values = JsonSerializer.Deserialize<List<T>>(data, _options);
            return values;
        }
    }
}
