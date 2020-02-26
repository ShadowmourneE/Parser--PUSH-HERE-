namespace ParseTheDocument
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class ParserExtension
    {
        public static string[] ChildrenCriteriaLetters = new string[] { "a)", "b)", "c)", "d)", "e)" }; 
        /// <summary>
        /// Get the number from string by pattern like '[NUMBER] text'. It will return NUMBER
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetTheCriterionNumber(string str)
        {
            var rootCriterion = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    for (int j = i; j < str.Length; j++)
                    {
                        if (char.IsDigit(str[j]))
                        {
                            rootCriterion.Add(str[j]);
                        }
                        else
                        {
                            return new string(rootCriterion.ToArray());
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        public static IEnumerable<string> FileToCollection(string pathToFile)
        {
            using (var sr = new StreamReader(pathToFile))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
        }

        /// <summary>
        /// Get the number template before node text like '[NUMBER].[NUMBER].[NUMBER] -> N times'
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static string GetCriterionNumberOfString(string str)
        {
            var built = new List<char>();
            for (var i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]) || str[i] == '.')
                {
                    for (int j = i; j < str.Length; j++)
                    {
                        if (Char.IsDigit(str[j]) || str[j] == '.')
                        {
                            built.Add(str[j]);
                        }
                        else
                        {
                            return new string(built.ToArray());
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Prepare entered text and join separated sentences
        /// </summary>
        public static IEnumerable<string> PrepareEnteredTextAsTemplateToParse(string pathToFile)
        {
            var result = new List<string>();

            var lines = File.ReadAllLines(pathToFile);
            void VisitingFileToGlueLinesByMind(string buildingLine, string[] linesRec, int nextIndex)
            {
                if (nextIndex < linesRec.Length)
                {
                    if (linesRec[nextIndex].StartsWith("Unit") || (char.IsDigit(linesRec[nextIndex][0]/*TODO: This condition is not enough to make sure*/)))
                    {
                        result.Add(buildingLine);
                        VisitingFileToGlueLinesByMind($"{linesRec[nextIndex]} ", linesRec, ++nextIndex);
                    }
                    else
                    {
                        VisitingFileToGlueLinesByMind($"{buildingLine + linesRec[nextIndex]} ", linesRec, ++nextIndex);
                    }
                }
                else
                {
                    return;
                }
            }
            VisitingFileToGlueLinesByMind(lines[0], lines, 1);

            return result;
        }

        /// <summary>
        /// This method checks if separating process is need
        /// </summary>
        /// <param name="currentCriteria"></param>
        /// <returns></returns>
        public static bool IsInOneLine(string currentCriteria) {
            //the most common condition for EAL quals;
            if (currentCriteria.Contains("of") && currentCriteria.Contains("the") && currentCriteria.Contains("following")) {
                var words = currentCriteria.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                for (var i = 0; i < words.Length; i ++) {
                    if (words[i] == "of" && words[i + 1] == "the" && (words[i + 2].Contains("following")))
                    {
                        if (words[i - 1] != "all" && words[i - 1] != "All")
                        {
                            return true;
                        }
                        else
                        {
                            for (var j = i; j < words.Length; j++) {
                                if (words[j].ContainsAny(ChildrenCriteriaLetters)) {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        public static bool ContainsAny(this string str, string[] arrayStrings) {
            for (var i = 0; i < arrayStrings.Length; i++) {
                if (arrayStrings[i].Contains(str)) {
                    return true;
                }
            }
            return false;
        }
    }
}
