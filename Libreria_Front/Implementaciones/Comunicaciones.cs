using System.Text;
using Libreria_Front.Interfaces;
using Newtonsoft.Json;

namespace Libreria_Front.Implementaciones
{
    public class Comunicaciones : IComunicaciones
    {
        public async Task<T> Ejecutar<T>(string url, object entidad)
        {
            url = "http://localhost:5080/" + url;

            var body = new StringContent(
                JsonConvert.SerializeObject(entidad),
                Encoding.UTF8, "application/json");

            var cliente_http = new HttpClient();
            cliente_http.Timeout = new TimeSpan(0, 4, 0);

            var message = await cliente_http.PostAsync(url, body);

            if (!message.IsSuccessStatusCode)
                throw new Exception("Error Comunicacion");

            var respuesta = await message.Content.ReadAsStringAsync();
            cliente_http.Dispose();
            cliente_http = null;

            respuesta = Replace(respuesta);
            return JsonConvert.DeserializeObject<T>(respuesta)!;
        }

        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
                .Replace("\\r\\n", "")
                .Replace("\\", "")
                .Replace("\\\"", "\"")
                .Replace("\"", "'")
                .Replace("'[", "[")
                .Replace("]'", "]")
                .Replace("'{'", "{'")
                .Replace("\\\\", "\\")
                .Replace("'}'", "'}")
                .Replace("}'", "}")
                .Replace("\\n", "")
                .Replace("\\r", "")
                .Replace("    ", "")
                .Replace("'{", "{")
                .Replace("\"", "")
                .Replace("  ", "")
                .Replace("null", "''");
        }
    }
}