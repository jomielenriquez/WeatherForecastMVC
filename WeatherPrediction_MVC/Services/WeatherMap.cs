using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPrediction_MVC.Services
{
    interface WeatherMap
    {
        Task<string> GetToken(string id, string appid);
    }
}
