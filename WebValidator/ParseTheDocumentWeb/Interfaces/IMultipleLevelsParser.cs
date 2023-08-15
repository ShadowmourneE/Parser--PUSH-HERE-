using Microsoft.AspNetCore.Http;
using static ParseTheDocumentWeb.MultipleLevelsParser;

namespace ParseTheDocumentWeb.Interfaces
{
    public interface IMultipleLevelsParser
    {
        void StartParseQualifications(string[] file);

        void StartParseStandarts(IFormFile file);

        event ParserErrorHandler CompletedNotify;
    }
}
