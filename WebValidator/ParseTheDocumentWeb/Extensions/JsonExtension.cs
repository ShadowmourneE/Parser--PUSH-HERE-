using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseTheDocumentWeb.Extensions
{
    public static class JsonExtension
    {
        private static int CurrentId = 0;
        public static string ReplaceIds(string json, int id)
        {
            CurrentId = id;
            string pattern = "\"Id\": " + @"\d+,";
            MatchEvaluator evaluator = new MatchEvaluator(ReplaceId);
            return Regex.Replace(json, pattern, evaluator, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            
        }
        private static string ReplaceId(Match match)
        {
            return "\"Id\": " + CurrentId++.ToString() + ",";
        }
    }
}
