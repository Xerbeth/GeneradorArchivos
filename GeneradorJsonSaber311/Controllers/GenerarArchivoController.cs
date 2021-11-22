using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GeneradorJsonSaber311.Dto;

namespace GeneradorJsonSaber311.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerarArchivoController : ControllerBase
    {
        public GenerarArchivoController()
        {
        }

        [HttpPost("GenerarArchivo")]
        public void Get(List<Item> items)
        {
            try
            {

                ProcesarArchivoController procesarArchivo = new ProcesarArchivoController();
                procesarArchivo.Crear(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        //[HttpPost("GenerarArchivo")]
        //public IEnumerable<string> Get(List<Item> items)
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}