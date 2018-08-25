using System.Xml.Serialization;

namespace ScoreCompare.MusicXml.Elements
{
    public enum YesNo
    {
        [XmlEnum("yes")]
        Yes,
        [XmlEnum("no")]
        No,
    }
}