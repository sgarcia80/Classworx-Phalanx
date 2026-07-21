using CobisAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CobisAPI.Controllers
{
    [ApiController]
    [Route("CTSRestAuthentication/resource/authenticate")]
    public class CTSRestAuthentication : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok("All right");
        }

        [HttpGet("relation")]
        public IActionResult Relation(string login, int application_id, int servicio)
        {
            Token token = new Token();
            string generatedToken = token.GetToken();


            if (string.IsNullOrEmpty(login))
            {
                return BadRequest("El parámetro login no es correcto.");
            }

            if (application_id != 27)
            {
                return BadRequest("El parámetro application_id no es correcto.");
            }

            if (servicio != 8)
            {
                return BadRequest("El parámetro servicio no es correcto.");
            }

            Response.Headers.Add(
                "Authorization",
                $"Bearer {generatedToken}");

            return Ok();
        }
    }
}
