using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParseTheDocumentWeb.Extensions;

namespace ParseTheDocumentWeb.Controllers
{
    public class JsonFixesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UpdateJson(IFormFile uploadedFile, int firstId)
        {
            if (uploadedFile != null && uploadedFile.ContentType == "application/json")
            {

                using var streamReader = new StreamReader(uploadedFile.OpenReadStream());
                string json = streamReader.ReadToEnd();
                json = JsonExtension.ReplaceIds(json, firstId);
                var jsonData = new
                {
                    dataURI = "data:text/json," + json,
                    fileName = uploadedFile.FileName
                };
                return Json(jsonData);
            }
            return null;
        }
    }
}