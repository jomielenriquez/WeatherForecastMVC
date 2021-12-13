using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using WeatherPrediction_MVC.Models;


namespace WeatherPrediction_MVC.Services
{
    public class WeatherMapClass:WeatherMap
    {
        private readonly HttpClient _httpClient;
        public WeatherMapClass(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetToken(string id, string appid)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "forecast");

            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic",Convert.ToBase64String(Encoding.UTF8.GetBytes($"{id}:{appid}"))
            );

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type","clien_creadentials"}
            });
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(responseStream);
            return authResult.clouds.ToString();
        }
    }
}