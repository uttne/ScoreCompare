using System.IO;
using System.Xml.Serialization;
using ScoreCompare.MusicXml.Elements;

namespace ScoreCompare.MusicXml
{
    public class Parser
    {
        public ScorePartwise Parse(string xmlText)
        {
            var serializer = new XmlSerializer(typeof(ScorePartwise));
            using (var ss = new StringReader(xmlText))
                return (ScorePartwise)serializer.Deserialize(ss);

        }
        
    }
}
