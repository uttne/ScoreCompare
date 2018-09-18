using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreCompare.Xml;

namespace ScoreCompare.Test.Xml
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void Parse_success()
        {
            var target = new Parser();

            var expected = new Syntax[]
            {
                new OpeningTag("<tag1>","tag1","tag1",null),
                new OpeningTag("<tag2>","tag2","tag2",null),
                new Data("12345","12345"),
                new ClosingTag("</tag2>","/tag2","tag2"),
                new OpeningTag("<tag3>","tag3","tag3",null),
                new Data("data","data"),
                new ClosingTag("</tag3>","/tag3","tag3"),
                new ClosingTag("</tag1>","/tag1","tag1"),
            };

            var xml = @"<tag1><tag2>12345</tag2><tag3>data</tag3></tag1>";

            var actual = target.Parse(xml).ToArray();

            CollectionAssert.AreEqual(expected,actual);
        }

    }
}
