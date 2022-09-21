using System.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Anbima.Infra.Data.HTTPClient
{
    public class Methods
    {
        public Methods()
        {

        }
        public async Task Get(string parametros)
        {
            var retorno = new byte[0];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationsKey.appSettingsValue("AnbimaApi"));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestContent = new StringContent(JsonSerializer.Serialize(parametros), Encoding.UTF8, "application/json");
                var result = await client.GetAsync("").ConfigureAwait(false);

                if (result.IsSuccessStatusCode)
                {
                    var retornoAPI = await result.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    retorno = retornoAPI;
                }
            }
        }
    }


    public static class ConfigurationsKey
    {
        public static string appSettingsValue(string key)
        {
            var ret = ConfigurationSettings.AppSettings[key];
            return ret;
        }
    }
}

