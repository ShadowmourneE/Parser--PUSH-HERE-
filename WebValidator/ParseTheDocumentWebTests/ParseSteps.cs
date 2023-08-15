using System;
using TechTalk.SpecFlow;
using ParseTheDocumentWeb;
using System.Collections.Generic;
using NUnit.Framework;
using ParseTheDocumentWeb.Extensions;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow.Assist;
using ParseTheDocumentWeb.Interfaces;
using ParseTheDocumentWeb.Models;

namespace ParseTheDocumentWebTests
{
    [Binding]
    public class ParseSteps
    {
        private List<IMessage> messages = new List<IMessage>(); 
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
            parser.StartParseQualifications(file.ToArray());
            messages.AddRange(parser.Errors);
            messages.AddRange(parser.Warnings);

        }
        [Then(@"all lines should be correctly")]
        public void ThenTheErrorsShouldBeCorrectly()
        {
            Assert.IsNull(SearchMessage(), messages.Any() ? messages.First().Message : string.Empty);
        }
        [Then(@"the line (\d+) should have message: (.*)")]
        public void ThenTheLineShouldBeHaveMessage(int row, string message)
        {
            Assert.AreEqual(message,FindMessage(row,message));
        }
        public string FindMessage(int row, string message)
        {
            if(messages.Find(m => m.Row == row && m.Message == message) != null)
            {
                return messages.Find(m => m.Row == row && m.Message == message).Message;
            }
            else if(messages.Find(m => m.Row == row) != null)
            {
                return messages.Find(m => m.Row == row).Message;
            }
            return string.Empty;
        }
        public List<IMessage> SearchMessage()
        {
            return messages.Any() ? messages : null;
        }
    }

}
