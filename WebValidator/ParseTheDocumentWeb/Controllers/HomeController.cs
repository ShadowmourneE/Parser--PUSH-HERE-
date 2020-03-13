namespace ParseTheDocumentWeb.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ParseTheDocumentWeb.Extensions;
    using ParseTheDocumentWeb.Interfaces;
    using ParseTheDocumentWeb.Models;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.Json;

    public class HomeController : Controller { 
        private readonly IMultipleLevelsParser _parser;
        private List<Error> _errors;
        private List<Warning> _warnings;

        public HomeController(IMultipleLevelsParser parser)
        {
            _parser = parser;
            _errors = new List<Error>();
            _warnings = new List<Warning>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ValidateFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var stream = uploadedFile.OpenReadStream();
                var file = ParserExtension.FileToCollection(stream);
                _parser.CompletedNotify += CompletedHandler;
                _parser.StartParse(file.ToArray());

            }
            return Json(new { errors = _errors, warnings = _warnings });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CompletedHandler(List<Error> errors, List<Warning> warnings)
        {
            if (errors.Any())
            {
                this._errors = errors;
            }
            if (warnings.Any()) {
                this._warnings = warnings;
            }
        }
    }
}
