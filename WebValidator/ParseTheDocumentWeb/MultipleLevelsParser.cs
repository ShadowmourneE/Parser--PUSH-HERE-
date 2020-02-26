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


        public MultipleLevelsParser() {
            _indexTemplate = $"1.1";
            _excelMapper = new Dictionary<string, string>();
            _errorsList = new List<string>();
            _warningsPairs = new List<string>();
        }


        public void StartParse(string[] file) {
            var indexTemplate = _indexTemplate;
            var counterForDeep = -2;
            var unitGlobal = 0;
            for (int node = 0; node < file.Length; node++) {
                if (!string.IsNullOrEmpty(file[node]))
                {
                    if (file[node].StartsWith("Unit"))
                    {
                        indexTemplate = _indexTemplate;
                        indexTemplate += $".{(++unitGlobal).ToString()}";

                        var isOk = _excelMapper.TryGetValue(indexTemplate, out var result);
                        if (!isOk)
                        {
                            _excelMapper.Add(indexTemplate, file[node]);
                        }
                        else
                        {
                            _errorsList.Add($"◉ line - {node + 1}. Not unique content or invalid string: string - {file[node]}; ");
                        }
                        counterForDeep = 0;
                        continue;
                    }

                    if (char.IsDigit(file[node][0]))
                    {
                        var depth = ParserExtension.GetCriterionNumberOfString(file[node]).Count(x => x == '.');
                        if (depth == 0)
                        {
                            var isOk = _excelMapper.TryGetValue(indexTemplate + $".{int.Parse(ParserExtension.GetTheCriterionNumber(file[node]))}", out var result);
                            if (!isOk) {
                                _excelMapper.Add(indexTemplate + $".{int.Parse(ParserExtension.GetTheCriterionNumber(file[node]))}", file[node]);
                            }
                            else {
                                _errorsList.Add($"◉ line - {node + 1}. Not unique content or invalid string: string - {file[node]}; ");
                            }
                        }
                        else if (depth > counterForDeep)
                        {
                            var nodeHasValue = BuildTree(node, ParserExtension.GetCriterionNumberOfString(file[node]), indexTemplate);
                            if (nodeHasValue.HasValue)
                            {
                                node = nodeHasValue.Value;
                            }
                            else
                            {
                                break;
                            }

                            int? BuildTree(int nodeIndexNext, string indexForCurrentStringNext, string template)
                            {
                                template += $".{indexForCurrentStringNext}";
                                try
                                {
                                    if(!char.IsDigit(file[nodeIndexNext][0]))
                                    {
                                        throw new Exception();
                                    }

                                    if (ParserExtension.DoesStringContainBoth(file[nodeIndexNext])) {
                                        _warningsPairs.Add($"◉ line - {nodeIndexNext + 1}. Check: check both ?- {file[nodeIndexNext]}; ");
                                    }

                                    if (!ParserExtension.IsInOneLine(file[nodeIndexNext])) {
                                        _warningsPairs.Add($"◉ line - {nodeIndexNext + 1}. Check: should not be in one line or vice versa ?- {file[nodeIndexNext]}; ");
                                    }
                                    if (!ParserExtension.IsValidContentForUnion(file[nodeIndexNext])) {
                                        _warningsPairs.Add($"◉ line - {nodeIndexNext + 1}. Check: check the content of current criteria ?- {file[nodeIndexNext]}; ");
                                    }

                                    if (ParserExtension.ContainsDirtyInfo(file[nodeIndexNext])) {
                                        _warningsPairs.Add($"◉ line - {nodeIndexNext + 1}. Check: maybe there useless information exists- {file[nodeIndexNext]}; ");
                                    }

                                    if (!template.IsTemplateValid()) {
                                        _errorsList.Add($"◉ line - {nodeIndexNext + 1}. Error: Template is not valid! Check the index at the beginning- {file[nodeIndexNext]}; ");
                                    
                                    }

                                    _excelMapper.Add(template, file[nodeIndexNext]);
                                }
                                catch (Exception e)
                                {
                                    _errorsList.Add($"◉ line - {nodeIndexNext + 1}. Not unique content or invalid string: string - {file[nodeIndexNext]}; ");
                                }
                                return nodeIndexNext + 1 < file.Length ?
                                        file[nodeIndexNext + 1].Count(x => x == '.') >= file[nodeIndexNext].Count(x => x == '.') ?
                                            BuildTree(nodeIndexNext + 1, ParserExtension.GetCriterionNumberOfString(file[nodeIndexNext + 1]), indexTemplate)
                                        : nodeIndexNext
                                    : null;
                            }
                        }
                    }
                    else {
                        _errorsList.Add($"◉ line - {node + 1}. String doesn't start with number");
                    }
                }
            }

            this.OnParsingCompleted();
        }

        private void OnParsingCompleted() {
            CompletedNotify?.Invoke(_errorsList, _warningsPairs);
        }
    }
}
