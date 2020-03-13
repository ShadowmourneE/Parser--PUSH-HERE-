using System;
using TechTalk.SpecFlow;
using ParseTheDocumentWeb;
using System.Collections.Generic;
using NUnit.Framework;
using ParseTheDocumentWeb.Extensions;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow.Assist;

namespace ParseTheDocumentWebTests
{
    [Binding]
    public class ParseSteps
    {
        private List<string> messages = new List<string>();
        private IEnumerable<string> file;
        private MultipleLevelsParser parser = new MultipleLevelsParser();
        [Given(@"I have entered:$")]
        public void GivenIHaveEntered(string file)
        {
            this.file = file.Split("\n");
        }
        [When(@"parse")]
        public void Parse()
        {
            parser.StartParse(file.ToArray());

        }
        [Then(@"the lines should be correctly")]
        public void ThenTheErrorsShouldBeCorrectly()
        {
            Assert.IsFalse(SearchMessage());
        }
        [Then(@"the line (\d+) should have message: (.*)")]
        public void ThenTheLineShouldBeHaveMessage(int row, string message)
        {
            Assert.IsTrue(FindMessage(row,message), message);
        }
        public bool FindMessage(int row, string message)
        {
            return parser.Errors.Any(error => error.Row == row && error.Message == message)
                || parser.Warnings.Any(warning => warning.Row == row && warning.Message == message);
        }
        public bool SearchMessage()
        {
            return parser.Errors.Any() || parser.Warnings.Any();
        }
    }

}
