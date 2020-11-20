using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FAQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThemeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
         {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public ThemeController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ThemeDTO> Get()
        {
            
            return new ThemeBLL().GetAll();
          
          
        }
    }
}
