using static ParseTheDocumentWeb.MultipleLevelsParser;

namespace ParseTheDocumentWeb.Interfaces
{
    public interface IMultipleLevelsParser
    {
        void StartParse(string[] file);
        event ParserErrorHandler CompletedNotify;
    }
}
