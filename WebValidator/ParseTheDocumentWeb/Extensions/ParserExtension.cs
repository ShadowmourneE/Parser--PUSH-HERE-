namespace ParseTheDocumentWeb.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

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
        /// 
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        public static IEnumerable<string> FileToCollection(Stream stream)
        {
            using var sr = new StreamReader(stream);
            while (!sr.EndOfStream)
            {
                yield return sr.ReadLine();
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

        public static bool ContainsDirtyInfo(string currentCriteria) {
            //for example pages numeration of odd labels
            //like EAL-AUEC3-005-Issue-A-0816 7 of 7 -TODO: need to investigate and implement.
            //
            var match = Regex.Match(currentCriteria, @"(\d*[ ]*of\d*[ ]*)");//need to refactor

            if (match.Success && match.Value.Trim() != "of")
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// This method checks if separating process is need
        /// </summary>
        /// <param name="currentCriteria"></param>
        /// <returns></returns>
        public static bool IsInOneLine(string currentCriteria) {
            if ((currentCriteria.Contains("of") || currentCriteria.Contains("from"))
                && currentCriteria.Contains("the") && currentCriteria.Contains("following")) {
                
                var words = GetWordsFromString(currentCriteria)
                    .ToArray();
                //first case
                for (var i = 0; i < words.Length; i++)
                {
                    if ((i +1 < words.Length) && (i + 2 < words.Length) && (words[i] == "of" || words[i] == "from") && words[i + 1] == "the" && words[i + 2].Contains("following"))
                    {
                        if (words[i - 1].ToLowerInvariant() != "all" && words.All(x => !x.ContainsAny(ChildrenCriteriaLetters)))
                        {
                            //one of the following and etc
                            return false;
                        }
                        else if(words[i - 1].ToLowerInvariant() == "all")
                        {
                            //if all of the following and in one line - throw warning
                            for (var j = i; j < words.Length; j++)
                            {
                                if (words[j].ContainsAny(ChildrenCriteriaLetters))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }
        //union string into one
        public static bool IsValidContentForUnion(string currentCriteria) {
            if ((currentCriteria.Contains("of") || currentCriteria.Contains("from"))
               && currentCriteria.Contains("the") && currentCriteria.Contains("following"))
            {
                var words = currentCriteria.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                if (words.Contains("Plus") || words.Contains("plus"))
                {
                    //second case
                    for (var i = 0; i < words.Length; i++)
                    {
                        if (words[i].ToLower() == "plus")
                        {
                            for (int j = i; j < words.Length; j++)
                            {
                                if ((words[j] == "of" || words[j] == "from") && words[j + 1] == "the" && (words[j + 2].Contains("following")))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }


        public static bool DoesStringContainBoth(string str) => str.Contains("both the following");

        /// <summary>
        /// The 'both' via context should be separate too.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="arrayStrings"></param>
        /// <returns></returns>
        public static bool IsTemplateValid(this string criteria)
        {
            var isValid = criteria.Split('.').Select((x) => int.TryParse(x, out var isParsed)).All(x => x);

            return isValid;
        }

        public static bool ContainsAny(this string str, string[] arrayStrings) {
            for (var i = 0; i < arrayStrings.Length; i++) {
                if (str.Contains(arrayStrings[i])) {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Returns a list of words with numbers without spaces
        /// </summary>
        /// <param name="sentence">string sentence</param>
        /// <returns></returns>
        /// NOTE: This method was written because there are different types of spaces not only ' ' or \t \s+ ... so it was 
        /// easier to filter in this way rather using Split and LINQ filters.(speed too)
        /// TODO: use Spans
        public static List<string> GetWordsFromString(string sentence)
        {
            
                var st = sentence.Trim();
                var resultCollection = new List<string>();
                string word = string.Empty;
                for (int? i = 0; i < st.Length; i++) {
                    if (!char.IsWhiteSpace(st[i.Value]))
                    {
                        for (int? j = i; j < st.Length; j++)
                        {
                            if (!char.IsWhiteSpace(st[j.Value]))
                            {
                                word += st[j.Value];
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(word))
                                {
                                    resultCollection.Add(word);
                                }
                                word = string.Empty;
                                i = j;
                                j = null;
                            }
                        }

                    }
                }
            
            return resultCollection;
        }
    }
}
