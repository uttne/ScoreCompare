using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreCompare.MusicXml;
using ScoreCompare.MusicXml.Elements;

namespace ScoreCompare.Test.MusicXml
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ConvertTo_success()
        {
            var target = new Parser();

            var xml = @"<?xml version='1.0' encoding='UTF-8'?>
<!DOCTYPE score-partwise PUBLIC '-//Recordare//DTD MusicXML 2.0 Partwise//EN' 'http://www.musicxml.org/dtds/partwise.dtd'>
<score-partwise version='1.2.3.4'>
  <work/>
  <movement-number/>
  <movement-title/>
  <identification/>
  <defaults/>
  <credit/>
  <credit/>
  <part-list/>
  <part/>
  <part/>
</score-partwise>
";

            var actual = target.Parse(xml);

            var expected = new ScorePartwise()
            {
                Work = new Work(),
                Credits = new CreditCollection()
                {
                    new Credit(),
                    new Credit()
                },
                Defaults = new Defaults(),
                Identification = new Identification(),
                MovementNumber = "",
                MovementTitle = "",
                PartList = new PartList(),
                Parts = new PartCollection()
                {
                    new Part(),
                    new Part(),
                },
                Version = "1.2.3.4"
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
