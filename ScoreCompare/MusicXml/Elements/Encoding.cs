using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ScoreCompare.MusicXml.Elements
{
    public class Encoding
    {
        [XmlElement("software",DataType ="string")]
        public string Software { get; set; }
        [XmlElement("encoding-date",DataType ="dateTime")]
        public DateTime EncodingDate { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Encoding);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Software != null ? Software.GetHashCode() : 0) * 397) ^ EncodingDate.GetHashCode();
            }
        }

        public bool Equals(Encoding obj)
        {
            return obj != null &&
                Software == obj.Software &&
                EncodingDate == obj.EncodingDate;
        }

    }
}