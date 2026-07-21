using CobisAPI.Model;
using CobisAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CobisAPI.Controllers
{
    [ApiController]
    [Route("CTSRestExecutor/resource/sp")]
    public class CTSRestExecutor : Controller
    {
        // GET: CTSRestExecutor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("execute")]
        public IActionResult Execute(
        [FromBody] SpRequest request)
        {
            string auth =
                Request.Headers.Authorization.FirstOrDefault();

            if (string.IsNullOrEmpty(auth))
            {
                Response.Headers.Append(
                    "Error-Code",
                    "MISSING_TOKEN");

                return BadRequest();
            }

            if (!auth?.StartsWith("Bearer ") ?? true)
            {
                return Unauthorized();
            }

            string token = auth.Substring("Bearer ".Length).Trim();
            Token tokenSservice = new Token();
            if (!tokenSservice.CheckToken(token))
            {
                return Ok(new
                {
                    resultSetListSize = 0,
                    returnCode = 1875069,
                    errorListSize = 0,
                    resultSets = Array.Empty<object>(),
                    dataMessageLoaded = true,
                    messages = new[]
                    {
                        new
                        {
                            messageText = "[sp_login] El login no corresponde al cliente seleccionado o no existe",
                            messageNumber = 1875069,
                            type = 3
                        }
                    },
                    @params = Array.Empty<object>(),
                    errors = Array.Empty<object>(),
                    messageListSize = 1
                });
            }

            if (request == null)
            {
                Response.Headers.Append(
                    "Error-Code",
                    "INVALID_REQUEST");

                return BadRequest();
            }

            if (string.IsNullOrEmpty(request.SpName))
            {
                Response.Headers.Append(
                    "Error-Code",
                    "INVALID_SPNAME");

                return BadRequest();
            }

            return Ok(new
            {
                resultSetListSize = 10,
                returnCode = 0,
                errorListSize = 0,
                resultSets = Array.Empty<object>(),
                dataMessageLoaded = true,
                messages = Array.Empty<object>(),
                @params = Array.Empty<object>(),
                errors = Array.Empty<object>(),
                messageListSize = 1
            });
        }

        // GET: CTSRestExecutor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CTSRestExecutor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CTSRestExecutor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CTSRestExecutor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CTSRestExecutor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CTSRestExecutor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
