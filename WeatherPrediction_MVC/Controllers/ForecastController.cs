using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherPrediction_MVC.Models;

namespace WeatherPrediction_MVC.Controllers
{
    public class ForecastController : Controller
    {
        // GET: Forecast
        public ActionResult Index()
        {
            //var test = new List<AuthResult> { };
            // This is my id and appid
            var test = Get("1683340", "1ae76ac0b8679d9b65ae01f37ea44b16");
            return Content(test.ToString());
        }
        
        [HttpGet]
        public async Task<string> Get(string id, string appid)
        {
            var URL = $"http://api.openweathermap.org/data/2.5/forecast?id={id}&appid={appid}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();

        }
    }
}