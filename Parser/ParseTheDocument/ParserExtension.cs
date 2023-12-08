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
    }
}
