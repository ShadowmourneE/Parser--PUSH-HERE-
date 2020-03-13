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
        [Then(@"all lines should be correctly")]
        public void ThenTheErrorsShouldBeCorrectly()
        {
            Assert.IsFalse(SearchMessage());
        }
        [Then(@"the line (\d+) should have message: (.*)")]
        public void ThenTheLineShouldBeHaveMessage(int row, string message)
        {
            Assert.AreEqual(FindMessage(row,message), message);
        }
        public string FindMessage(int row, string message)
        {
            if(parser.Errors.Find(error => error.Row == row && error.Message == message) != null)
            {
                return parser.Errors.Find(error => error.Row == row && error.Message == message).Message;
            }
            else if(parser.Warnings.Find(warning => warning.Row == row && warning.Message == message) != null)
            {
                return parser.Warnings.Find(warning => warning.Row == row && warning.Message == message).Message;
            }
            if(parser.Errors.Find(error => error.Row == row) != null)
            {
                return parser.Errors.Find(error => error.Row == row).Message;
            }else if (parser.Warnings.Find(warning => warning.Row == row) != null)
            {
                return parser.Warnings.Find(warning => warning.Row == row).Message;
            }
            return string.Empty;
        }
        public bool SearchMessage()
        {
            return parser.Errors.Any() || parser.Warnings.Any();
        }
    }

}
