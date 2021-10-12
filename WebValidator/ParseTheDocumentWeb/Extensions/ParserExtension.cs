namespace ParseTheDocumentWeb.Extensions
{
    using ParseTheDocumentWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class ParserExtension
    {
        public enum State
        {
            UnCorrect,
            Correct,
            NeedCheckWarning
        }
        public static Regex[] doesNotHaveChild = new Regex[]
        {
            new Regex(@"following|plus",RegexOptions.Compiled|RegexOptions.IgnoreCase),
            new Regex(@"(((of)|(from)|(with)|(using))\s+(the\s+)?(following\s+)?)(.*\s+((plus)|(and)|(or)).*\s+((from)|(of)|(with)|(using))\sthe\sfollowing)", RegexOptions.Compiled|RegexOptions.IgnoreCase),
            new Regex(@"(((include)(with)|(using)\s+)?((one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)|(ten)|(eleven)|(twelve)|(more))\s+)?((of)|(from)|(with)|(using))?\s+(the\s+)?following.*:\s*•?\s*\w+", RegexOptions.Compiled|RegexOptions.IgnoreCase),
            new Regex(@"include:(\s+\w+)+", RegexOptions.Compiled|RegexOptions.IgnoreCase)
        };
        public static Regex[] doesHaveChild = new Regex[]
        {
            new Regex(@"following|plus",RegexOptions.Compiled|RegexOptions.IgnoreCase),
            new Regex(@"(?<!(following).*)(?:(?:all)|(?:both))\s+(?:(?:from)|(?:of)\s+)?the\s+following((?!following).)*$", RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static Regex[] incorrectString = new Regex[]
        {
            new Regex(@"following|plus",RegexOptions.Compiled|RegexOptions.IgnoreCase),
            new Regex(@"(?<!(following|using|include).*)\s+plus", RegexOptions.Compiled | RegexOptions.IgnoreCase),
            new Regex(@"(?<!\b((or)|(and)|(plus)|(following))\b.*)(?:(?:all)|(?:both))\s+(?:(?:from)|(?:of)\s+)?the\s+following[^)\d,;]*(?:([a-z]\))|(\d+(\.\d+)*))((?!(following))[^:])*$", RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
        public static Regex[] checkWarnings = new Regex[]
        {
            new Regex(@".*(following).*", RegexOptions.Compiled | RegexOptions.IgnoreCase)
        };
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
            var regex = new Regex(@"^\d+(\.\d+)*");
            Match result = regex.Match(str);
            if (result.Success)
                return result.Groups[0].Value;
            else
                return string.Empty;
        }

        /// <summary>
        /// Prepare entered text and join separated sentences
        /// </summary>
        public static bool ContainsDirtyInfo(string currentCriteria)
        {
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


        public static State DoesHaveChild(string currentCriteria, string currentRoot, string nextRoot)
        {
            if (doesHaveChild.First().IsMatch(currentCriteria))
            {
                bool nextRootIsCorrectly;
                if (String.IsNullOrEmpty(nextRoot))
                {
                    nextRootIsCorrectly = true;
                }
                else
                {
                    nextRoot = GetCriterionNumberOfString(nextRoot);
                    nextRootIsCorrectly = NumberingChecks.CheckRoot(currentRoot, nextRoot);
                }
                foreach (var regex in doesHaveChild.Skip(1))
                {
                    var match = regex.Match(currentCriteria);
                    if (match.Success)
                    {
                        if (nextRootIsCorrectly)
                        {
                            return State.Correct;
                        }
                        else
                        {
                            return State.UnCorrect;
                        }
                    }
                }
            }
            return State.NeedCheckWarning;
        }
        public static State DoesNotHaveChild(string currentCriteria, string currentRoot, string nextRoot)
        {
            if (doesHaveChild.First().IsMatch(currentCriteria))
            {
                bool nextRootIsUnCorrect;
                if (String.IsNullOrEmpty(nextRoot) || nextRoot.StartsWith("Unit"))
                {
                    nextRootIsUnCorrect = false;
                }
                else
                {
                    nextRoot = GetCriterionNumberOfString(nextRoot);
                    nextRootIsUnCorrect = NumberingChecks.CheckRoot(currentRoot, nextRoot);
                }
                foreach (var regex in doesNotHaveChild.Skip(1))
                {
                    var match = regex.Match(currentCriteria);
                    if (match.Success)
                    {
                        if (nextRootIsUnCorrect)
                        {
                            return State.UnCorrect;
                        }
                        return State.Correct;
                    }
                }
            }
            return State.NeedCheckWarning;
        }
        public static bool InCorrectString(string currentCriteria)
        {
            if (doesHaveChild.First().IsMatch(currentCriteria))
            {
                foreach (var regex in incorrectString.Skip(1))
                {
                    var match = regex.Match(currentCriteria);
                    if (match.Success)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool CheckWarnings(string currentCriteria)
        {
            foreach (var regex in checkWarnings)
            {
                var match = regex.Match(currentCriteria);
                if (match.Success)
                {
                    if (!String.IsNullOrEmpty(match.Groups[1].Value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //union string into one


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
        public static Unit GetUnit(string line, int row)
        {
            var regex = new Regex(@".*:([^\r$]*)");
            var match = regex.Match(line);
            if (match.Success)
            {
                return new Unit { Name = match.Groups[1].Value, Row =  row};
            }
            return null;
        }

        public static bool CheckForDuplicated(string currentCriteria, string previouslyCriteria)
        {
            var criteriaNumberRegex = new Regex(@"^\d+(\.\d+)*");
            currentCriteria = criteriaNumberRegex.Replace(currentCriteria, string.Empty).Trim('\r'); ;
            previouslyCriteria = criteriaNumberRegex.Replace(previouslyCriteria, string.Empty).Trim('\r');
            if (string.CompareOrdinal(currentCriteria, previouslyCriteria) == 0) {
                return true;
            }

            return false;
        }
    }
}
