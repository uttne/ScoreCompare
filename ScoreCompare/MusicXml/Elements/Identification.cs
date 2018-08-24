using System.Collections.Generic;
using System.Xml.Serialization;

namespace ScoreCompare.MusicXml.Elements
{
    public class Identification
    {
        [XmlElement("encoding",Type =typeof(Encoding))]
        public Encoding Encoding { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Identification);
        }

        public override int GetHashCode()
        {
            return (Encoding != null ? Encoding.GetHashCode() : 0);
        }

        public bool Equals(Identification obj)
        {
            return obj != null &&
                EqualityComparer<Encoding>.Default.Equals(Encoding,obj.Encoding);
        }

    }
}