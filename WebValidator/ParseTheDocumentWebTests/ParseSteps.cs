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
            messages.AddRange(parser.ErrorsList);
            messages.AddRange(parser.WarningsPairs);

        }
        [Then(@"the lines should be correctly")]
        public void ThenTheErrorsShouldBeCorrectly()
        {
            Assert.IsFalse(SearchMessage());
        }
        [Then(@"the line should be correctly: (.*)")]
        public void ThenTheLineShouldBeCorrectly(string line)
        {
            Assert.IsFalse(FindMessageByLine(line));
        }
        [Then(@"the lines should be have message")]
        public void ThenTheErrorsShouldBeHaveMessage()
        {
            Assert.IsTrue(SearchMessage());
        }
        [Then(@"the line should be have message: (.*)")]
        public void ThenTheLineShouldBeHaveMessage(string message)
        {
            Assert.IsTrue(FindMessage(message));
        }
        public bool SearchMessage()
        {
            bool isExist = false;
            if (parser.WarningsPairs.Any() || parser.ErrorsList.Any())
            {
                isExist = true;
            }
            return isExist;
        }
        public bool FindError(string line)
        {
            var regex = new Regex("line - " + line + ".");
            foreach (var error in parser.ErrorsList)
            {
                if (regex.Match(error).Success)
                {
                    return true;
                }
            }
            return false;
        }
        public bool FindWarning(string line)
        {
            var regex = new Regex("line - " + line + ".");
            foreach (var error in parser.WarningsPairs)
            {
                if (regex.Match(error).Success)
                {
                    return true;
                }
            }
            return false;
        }
        public bool FindMessage(string message)
        {
            var regex = new Regex(message);
            foreach (var error in messages)
            {
                if (regex.Match(error).Success)
                {
                    return true;
                }
            }
            return false;
        }
        public bool FindMessageByLine(string line)
        {
            var regex = new Regex("line - " + line + ".");
            foreach (var error in messages)
            {
                if (regex.Match(error).Success)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
