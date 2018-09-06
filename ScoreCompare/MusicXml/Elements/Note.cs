using System.Xml.Serialization;

namespace ScoreCompare.MusicXml.Elements
{
    /// <summary>
    /// reference
    /// http://usermanuals.musicxml.com/MusicXML/MusicXML.htm#EL-MusicXML-note.htm?Highlight=note
    /// </summary>
    public class Note
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Type:tenths</remarks>
        [XmlAttribute(AttributeName = "default-x")]
        public decimal DefaultX { get; set; }
        [XmlIgnore]
        public bool DefaultXSpecified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Type:tenths</remarks>
        [XmlAttribute(AttributeName = "default-y")]
        public decimal DefaultY { get; set; }
        [XmlIgnore]
        public bool DefaultYSpecified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Type:tenths</remarks>
        [XmlAttribute(AttributeName = "relative-x")]
        public decimal RelativeX { get; set; }
        [XmlIgnore]
        public bool RelativeXSpecified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Type:tenths</remarks>
        [XmlAttribute(AttributeName = "relative-y")]
        public decimal RelativeY { get; set; }
        [XmlIgnore]
        public bool RelativeYSpecified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Type:comma-separated-text</remarks>
        [XmlAttribute(AttributeName = "font-family",DataType = "token")]
        public string FontFamily { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Type:font-style</remarks>
        [XmlAttribute(AttributeName = "font-style", DataType = "token")]
        public string FontStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Type:anySimpleType</remarks>
        [XmlAttribute(AttributeName = "font-size ")]
        public string FontSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Type:font-weight</remarks>
        [XmlAttribute(AttributeName = "font-weight", DataType = "token")]
        public string FontWeight { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as Note);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Note obj)
        {
            return obj != null;
        }

    }
}