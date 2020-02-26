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

    public class HomeController : Controller { 
        private readonly IMultipleLevelsParser _parser;
        private List<string> _errors;
        private List<string> _warningsPairs;

        public HomeController(IMultipleLevelsParser parser)
        {
            _parser = parser;
            _errors = new List<string>();
            _warningsPairs = new List<string>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var stream = uploadedFile.OpenReadStream();
                var file = ParserExtension.FileToCollection(stream);
                _parser.CompletedNotify += CompletedHandler;
                _parser.StartParse(file.ToArray());

            }

            return Ok(new { _errors, _warningsPairs });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CompletedHandler(List<string> errors, List<string> warningsPairs)
        {
            if (errors.Any())
            {
                this._errors = errors;
            }
            if (warningsPairs.Any()) {
                this._warningsPairs = warningsPairs;
            }
        }
    }
}
