namespace ParseTheDocumentWeb
{
    using ParseTheDocumentWeb.Extensions;
    using ParseTheDocumentWeb.Interfaces;
    using ParseTheDocumentWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class MultipleLevelsParser : IMultipleLevelsParser
    {
        private string _indexTemplate;
        private Dictionary<string, string> _excelMapper;
        private List<Error> _errors;
        private List<Warning> _warnings;
        private List<string> _errorsList;
        private List<string> _warningsPairs;
        private HashSet<Unit> _units;
        public delegate void ParserErrorHandler(List<Error> errors, List<Warning> warnings);
        public event ParserErrorHandler CompletedNotify;
        public List<Error> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }
        public List<Warning> Warnings
        {
            get { return _warnings; }
            set { _warnings = value; }
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
            _errors = new List<Error>();
            _warnings = new List<Warning>();
            _errorsList = new List<string>();
            _warningsPairs = new List<string>();
            _units = new HashSet<Unit>();
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
                        var unit = ParserExtension.GetUnit(file[rowIndex], rowIndex + 1);
                        if (unit == null)
                            _errors.Add(new Error { Row = rowIndex + 1, Message = "Unit title is wrong format", Line = file[rowIndex] });
                        else 
                            if (_units.Any(u => u.Name == unit.Name && u.Row != unit.Row) && !_errors.Any(u => u.Row == unit.Row))
                                _errors.Add(new Error { Row = rowIndex + 1, Message = "Unit with the same name already exist", Line = file[rowIndex] + " ◎◎◎" + " Look at line - " + _units.First(u => u.Name == unit.Name && u.Row != unit.Row).Row + "." });
                            else 
                                if (!_units.Any(u => u.Name == unit.Name))
                                    _units.Add(unit);
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
                            _errors.Add(new Error { Row = rowIndex + 1, Message = "String doesn't start with number", Line = file[rowIndex] });
                        }
                        else
                        {
                            if (prevNodeNumber != string.Empty && (nestingLevelCurrent > nestingLevelPrev))
                            {
                                //current 1.1.1.3.1 prev 1.1.1.3 check 1.1.1.3==1.1.1.3
                                if (!NumberingChecks.CheckRoot(prevNodeNumber, currentNodeNumberFull))
                                {
                                    _errors.Add(new Error { Row = rowIndex + 1, Message = "Nesting does't match previous", Line = file[rowIndex] });
                                }
                                rowIndex = BuildTree(rowIndex, prevNodeNumber);
                            }
                            else if (nestingLevelCurrent < nestingLevelPrev)
                            {
                                //current 1.1.1.4 prev 1.1.1.3.1 check 1.1.1 == 1.1.1 and 4>3
                                if (!NumberingChecks.CheckNumberingPrev(prevNodeNumber, currentNodeNumberFull))
                                {
                                    _errors.Add(new Error { Row = rowIndex + 1, Message = "Nesting does't match previous", Line = file[rowIndex] });
                                }
                                return --rowIndex;
                            }
                            else
                            {
                                if (!NumberingChecks.CheckNumberingCurrent(prevNodeNumber, currentNodeNumberFull))
                                {
                                    _errors.Add(new Error { Row = rowIndex + 1, Message = "Nesting does't match previous", Line = file[rowIndex] });
                                }
                                if (!NumberingChecks.IsCorrectNumbering(prevNodeNumber, currentNodeNumberFull))
                                {
                                    _errors.Add(new Error { Row = rowIndex + 1, Message = "Wrong numbering", Line = file[rowIndex] });
                                }
                                try
                                {
                                    bool needCheckWarning = false;
                                    bool haveError = false;
                                    switch (ParserExtension.DoesHaveChild(file[rowIndex], currentNodeNumber, rowIndex + 1 >= file.Length ? null : file[rowIndex + 1]))//check  regexp
                                    {
                                        case ParserExtension.State.UnCorrect:
                                            _errors.Add(new Error { Row = rowIndex + 1, Message = "Line in the wrong format for children", Line = file[rowIndex] });
                                            haveError = true;
                                            break;
                                        case ParserExtension.State.Correct:
                                            break;
                                        case ParserExtension.State.NeedCheckWarning:
                                            needCheckWarning = true;
                                            switch (ParserExtension.DoesNotHaveChild(file[rowIndex], currentNodeNumber, rowIndex + 1 >= file.Length ? null : file[rowIndex + 1])) //check  regexp
                                            {
                                                case ParserExtension.State.UnCorrect:
                                                    _errors.Add(new Error { Row = rowIndex + 1, Message = "Line is not formatted correctly for concatenation", Line = file[rowIndex] });
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
                                            _errors.Add(new Error { Row = rowIndex + 1, Message = "Incorrect string", Line = file[rowIndex] });
                                            haveError = true;
                                        }
                                    }
                                    //if (!haveError && needCheckWarning)
                                    //{
                                    //    if (!ParserExtension.CheckWarnings(file[rowIndex]))// check warning regexp
                                    //    {
                                    //        _warnings.Add(new Warning { Row = rowIndex + 1, Message = "Check this line", Line = file[rowIndex] });
                                    //    }
                                    //}
                                    if (ParserExtension.ContainsDirtyInfo(file[rowIndex]))
                                    {
                                        _warnings.Add(new Warning { Row = rowIndex + 1, Message = "Maybe there useless information exists", Line = file[rowIndex] });
                                    }

                                    if (!currentNodeNumberFull.IsTemplateValid())
                                    {
                                        _errors.Add(new Error { Row = rowIndex + 1, Message = "Template is not valid!", Line = file[rowIndex] });
                                    }

                                }
                                catch (Exception e)
                                {
                                    if (!_errors.Where(error => error.Message.Contains("Nesting does't match previous") && error.Row == rowIndex + 1).Any())
                                    {
                                        _errors.Add(new Error { Row = rowIndex + 1, Message = "Not unique content or invalid string", Line = file[rowIndex] });
                                    }
                                }

                                if (rowIndex != 0 && ParserExtension.CheckForDuplicated(file[rowIndex], file[rowIndex - 1]))
                                {
                                    _errors.Add(new Error { Row = rowIndex + 1, Message = "Duplicated criteria", Line = file[rowIndex] });
                                }

                                prevNodeNumber = currentNodeNumberFull;
                                if (!_excelMapper.ContainsKey(currentNodeNumberFull))
                                {
                                    _excelMapper.Add(currentNodeNumberFull, file[rowIndex]);
                                }
                                else
                                {
                                    if (!_errors.Where(error => error.Message.Contains("Nesting does't match previous") && error.Row == rowIndex + 1).Any())
                                    {
                                        _errors.Add(new Error { Row = rowIndex + 1, Message = "Not unique content or invalid string", Line = file[rowIndex] });
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
            CompletedNotify?.Invoke(_errors, _warnings);
        }
    }
}
