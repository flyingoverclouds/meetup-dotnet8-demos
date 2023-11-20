using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApiDivision.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisionController : ControllerBase
    {

        private readonly ILogger<DivisionController> _logger;

        public DivisionController(ILogger<DivisionController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetDivisionResult")]
        public float GetDivision(float numerateur, float denominateur) 
        {
            _logger.LogInformation($"Division de {numerateur} par {denominateur}");
            var result = numerateur / denominateur;
            _logger.LogInformation($"Le résultat est {result}");

            return result;
        }
    }
}
