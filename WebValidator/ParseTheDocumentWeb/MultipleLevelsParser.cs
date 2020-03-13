namespace ParseTheDocumentWeb
{
    using ParseTheDocumentWeb.Extensions;
    using ParseTheDocumentWeb.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MultipleLevelsParser : IMultipleLevelsParser
    {
        private string _indexTemplate;
        private Dictionary<string, string> _excelMapper;
        private List<string> _errorsList;
        private List<string> _warningsPairs;
        public delegate void ParserErrorHandler(List<string> errorsPairs, List<string> warningsPairs);
        public event ParserErrorHandler CompletedNotify;
        public List<string> ErrorsList
        {
            get { return _errorsList; }
            set { _errorsList = value; }
        }
        public List<string> WarningsPairs
        {
            get { return _warningsPairs; }
            set { _warningsPairs = value; }
        }


        public MultipleLevelsParser()
        {
            _indexTemplate = $"1.1";
            _excelMapper = new Dictionary<string, string>();
            _errorsList = new List<string>();
            _warningsPairs = new List<string>();
        }


        public void StartParse(string[] file)
        {
            _excelMapper = new Dictionary<string, string>(file.Length);
            _errorsList = new List<string>();
            _warningsPairs = new List<string>();
            var unitNumber = _indexTemplate;
            var unitIndex = 0;

            BuildTree(0, "");

            int BuildTree(int rowIndex, string parentNodeNumber)
            {
                var prevNodeNumber = string.Empty;
                while (rowIndex < file.Length)
                {
                    if (file[rowIndex].StartsWith("Unit"))
                    {
                        unitNumber = $"{_indexTemplate}.{++unitIndex}";
                        if (string.IsNullOrWhiteSpace(parentNodeNumber))
                        {
                            _excelMapper.Add(unitNumber, file[rowIndex]);
                            rowIndex = BuildTree(rowIndex + 1, unitNumber);
                        }
                        else
                        {
                            return --rowIndex;
                        }
                    }
                    else
                    {
                        var currentNodeNumber = ParserExtension.GetCriterionNumberOfString(file[rowIndex]);
                        var currentNodeNumberFull = $"{unitNumber}.{currentNodeNumber}";
                        int nestingLevelCurrent = currentNodeNumberFull.Count(x => x == '.');
                        int nestingLevelPrev = prevNodeNumber.Count(x => x == '.');

                        if (string.IsNullOrWhiteSpace(currentNodeNumber))
                        {
                            _errorsList.Add($"line - {rowIndex + 1}. String doesn't start with number");
                        }
                        else
                        {
                            if (prevNodeNumber != string.Empty && (nestingLevelCurrent > nestingLevelPrev))
                            {
                                //current 1.1.1.3.1 prev 1.1.1.3 check 1.1.1.3==1.1.1.3
                                if (!NumberingChecks.CheckRoot(prevNodeNumber, currentNodeNumberFull))
                                {
                                    _errorsList.Add($"line - { rowIndex + 1}. nesting does't match previous ?- {file[rowIndex]};");
                                }
                                rowIndex = BuildTree(rowIndex, prevNodeNumber);
                            }
                            else if (nestingLevelCurrent < nestingLevelPrev)
                            {
                                //current 1.1.1.4 prev 1.1.1.3.1 check 1.1.1 == 1.1.1 and 4>3
                                if (!NumberingChecks.CheckNumberingPrev(prevNodeNumber, currentNodeNumberFull))
                                {
                                    _errorsList.Add($"line - { rowIndex + 1}. nesting does't match previous ?- {file[rowIndex]};");
                                }
                                return --rowIndex;
                            }
                            else
                            {
                                //current 1.1.1.3.2 prev 1.1.1.3.1 check 1.1.1.3 == 1.1.1.3 and 2>1
                                if (!NumberingChecks.CheckNumberingCurrent(prevNodeNumber, currentNodeNumberFull))
                                {
                                    _errorsList.Add($"line - { rowIndex + 1}. nesting does't match previous ?- {file[rowIndex]};");
                                }
                                try
                                {
                                    bool needCheckWarning = false;
                                    bool haveError = false;
                                    switch (ParserExtension.DoesHaveChild(file[rowIndex], currentNodeNumber, rowIndex + 1 >= file.Length ? null : file[rowIndex + 1]))//check  regexp
                                    {
                                        case ParserExtension.State.UnCorrect:
                                            _errorsList.Add($"line - {rowIndex + 1}.  line is not formatted correctly for concatenation ?- {file[rowIndex]}; ");
                                            haveError = true;
                                            break;
                                        case ParserExtension.State.Correct:
                                            break;
                                        case ParserExtension.State.NeedCheckWarning:
                                            needCheckWarning = true;
                                            switch (ParserExtension.DoesNotHaveChild(file[rowIndex], currentNodeNumber, rowIndex + 1 >= file.Length ? null : file[rowIndex + 1])) //check  regexp
                                            {
                                                case ParserExtension.State.UnCorrect:
                                                    _errorsList.Add($"line - {rowIndex + 1}. line in the wrong format for children ?- {file[rowIndex]}; ");
                                                    haveError = true;
                                                    needCheckWarning = false;
                                                    break;
                                                case ParserExtension.State.Correct:
                                                    needCheckWarning = false;
                                                    break;
                                                case ParserExtension.State.NeedCheckWarning:
                                                    needCheckWarning = true;
                                                    break;
                                            }
                                            break;
                                    }
                                    if (!haveError)//check  regexp
                                    {
                                        if (ParserExtension.InCorrectString(file[rowIndex]))
                                        {
                                            _errorsList.Add($"line - {rowIndex + 1}. incorrect string ?- {file[rowIndex]}; ");
                                            haveError = true;
                                        }
                                    }
                                    if (!haveError && needCheckWarning)
                                    {
                                        if (!ParserExtension.CheckWarnings(file[rowIndex]))// check warning regexp
                                        {
                                            _warningsPairs.Add($"line - {rowIndex + 1}. check this line ?- {file[rowIndex]};");
                                        }
                                    }
                                    if (ParserExtension.ContainsDirtyInfo(file[rowIndex]))
                                    {
                                        _warningsPairs.Add($"line - {rowIndex + 1}. Check: maybe there useless information exists- {file[rowIndex]}; ");
                                    }

                                    if (!currentNodeNumberFull.IsTemplateValid())
                                    {
                                        _errorsList.Add($"line - {rowIndex + 1}. Error: Template is not valid! Check the index at the beginning- {file[rowIndex]}; ");
                                    }

                                    //_excelMapper.Add(currentNodeNumberFull, file[rowIndex]);
                                }
                                catch (Exception e)
                                {
                                    _errorsList.Add($"line - {rowIndex + 1}. Not unique content or invalid string: string - {file[rowIndex]};");
                                }

                                prevNodeNumber = currentNodeNumberFull;
                                if (!_excelMapper.ContainsKey(currentNodeNumberFull))
                                {
                                    _excelMapper.Add(currentNodeNumberFull, file[rowIndex]);
                                }
                                else
                                {
                                    if (!_errorsList.Contains($"line - { rowIndex + 1}. nesting does't match previous ?- {file[rowIndex]};"))
                                    {
                                        _errorsList.Add($"line - {rowIndex + 1}. Not unique content or invalid string: string - {file[rowIndex]}; ");
                                    }
                                }
                            }
                        }
                    }

                    rowIndex++;
                }
                return rowIndex;
            }


            this.OnParsingCompleted();
        }

        private void OnParsingCompleted()
        {
            CompletedNotify?.Invoke(_errorsList, _warningsPairs);
        }
    }
}
