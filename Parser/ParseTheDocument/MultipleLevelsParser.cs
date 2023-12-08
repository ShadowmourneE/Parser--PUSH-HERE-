namespace ParseTheDocument
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class MultipleLevelsParser
    {
        private string _indexTemplate;
        private Dictionary<string, string> _excelMapper;
        private Dictionary<string, string> _errorsPairs;
        private Dictionary<string, string> _warningsPairs;


        public MultipleLevelsParser() {
            _indexTemplate = $"1.1";
            _excelMapper = new Dictionary<string, string>();
            _errorsPairs = new Dictionary<string, string>();
            _warningsPairs = new Dictionary<string, string>();
        }

        public async Task ExportToExcelAsync(string fileName) {
            await Task.Run(() =>
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workBook = excelApp.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet workSheet = workBook.ActiveSheet;
                // set each cell's format to Text
                workSheet.Cells.NumberFormat = "@";

                workSheet.Cells[1, "A"] = "Index";
                workSheet.Cells[1, "B"] = "Name";
                workSheet.Cells[1, "C"] = "AimReferences";
                workSheet.Cells[1, "D"] = "Description";
                workSheet.Cells[1, "E"] = "Type";
                workSheet.Cells[1, "F"] = "Level";

                workSheet.Cells[2, "E"] = "LearningFramework";
                workSheet.Cells[3, "E"] = "Qualification";
                workSheet.Cells[2, "A"] = "1";
                workSheet.Cells[3, "A"] = "1.1";
                int j = 0;
                for (var i = 4; j < _excelMapper.Count; i++)
                {
                    if (_excelMapper.ElementAt(j).Key.Last() == '.')
                    {
                        workSheet.Cells[i, "A"] = _excelMapper.ElementAt(j).Key.Substring(0, _excelMapper.ElementAt(j).Key.Length - 1);
                    }
                    else {
                        workSheet.Cells[i, "A"] = _excelMapper.ElementAt(j).Key;
                    }
                    var value = _excelMapper.ElementAt(j).Value;
                    workSheet.Cells[i, "B"] = value;
                    if (value.StartsWith("Unit"))
                    {
                        workSheet.Cells[i, "E"] = "Unit";
                    }
                    else
                    {
                        workSheet.Cells[i, "E"] = "Criterion";
                    }
                    j++;
                }

                workBook.Close(true, fileName);
                excelApp.Quit();
            });
        }

        public void StartParse(string pathToFile) {

            var file = ParserExtension.FileToCollection(pathToFile).ToArray();
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
                        _excelMapper.Add(indexTemplate, file[node]);
                        counterForDeep = 0;
                        continue;
                    }

                    if (char.IsDigit(file[node][0]))
                    {
                        var depth = ParserExtension.GetCriterionNumberOfString(file[node]).Count(x => x == '.');
                        if (depth == 0)
                        {
                            _excelMapper.Add(indexTemplate + $".{int.Parse(ParserExtension.GetTheCriterionNumber(file[node]))}", file[node]);
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
                                _excelMapper.Add(template, file[nodeIndexNext]);
                                return nodeIndexNext + 1 < file.Length ?
                                        file[nodeIndexNext + 1].Count(x => x == '.') >= file[nodeIndexNext].Count(x => x == '.') && !file[nodeIndexNext + 1].StartsWith("Unit") ?
                                            BuildTree(nodeIndexNext + 1, ParserExtension.GetCriterionNumberOfString(file[nodeIndexNext + 1]), indexTemplate)
                                        : nodeIndexNext
                                    : null;
                            }
                        }
                    }
                }
            }
        }
    }
}
