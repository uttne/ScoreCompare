using System.Collections.Generic;
using System.Xml.Serialization;

namespace ScoreCompare.MusicXml.Elements
{
    /// <summary>
    /// The attributes element contains musical information that typically changes on measure boundaries.
    /// This includes key and time signatures, clefs, transpositions, and staving.
    /// When attributes are changed mid-measure, it affects the music in score order, not in MusicXML document order.
    ///
    /// reference
    /// http://usermanuals.musicxml.com/MusicXML/MusicXML.htm#CT-MusicXML-attributes.htm
    /// </summary>
    public class Attributes
    {
        private ElementCollection<Key> _keys;
        private ElementCollection<Time> _times;
        private ElementCollection<Clef> _clefs;
        private ElementCollection<StaffDetails> _staffDetails;
        private ElementCollection<Transpose> _transposes;
        private ElementCollection<string> _directives;
        private ElementCollection<MeasureStyle> _measureStyles;

        [XmlElement(ElementName = "footnote", Type = typeof(FormattedText))]
        public FormattedText Footnote { get; set; }

        [XmlElement(ElementName = "level", Type = typeof(Level))]
        public Level Level { get; set; }

        [XmlElement(ElementName = "divisions", Type = typeof(PositiveDivisions))]
        public PositiveDivisions Divisions { get; set; }

        [XmlElement(ElementName = "key", Type = typeof(Key))]
        public ElementCollection<Key> Keys
        {
            get => _keys ?? (_keys = new ElementCollection<Key>());
            set => _keys = value;
        }

        [XmlElement(ElementName = "time", Type = typeof(Time))]
        public ElementCollection<Time> Times
        {
            get => _times ?? (_times = new ElementCollection<Time>());
            set => _times = value;
        }

        [XmlElement(ElementName = "staves", DataType = "nonNegativeInteger")]
        public string Staves { get; set; }

        [XmlElement(ElementName = "part-symbol", Type = typeof(PartSymbol))]
        public PartSymbol PartSymbol { get; set; }

        [XmlElement(ElementName = "instruments", DataType = "nonNegativeInteger")]
        public string Instruments { get; set; }

        [XmlElement(ElementName = "clef", Type = typeof(Clef))]
        public ElementCollection<Clef> Clefs
        {
            get => _clefs ?? (_clefs = new ElementCollection<Clef>());
            set => _clefs = value;
        }

        [XmlElement(ElementName = "staff-details", Type = typeof(StaffDetails))]
        public ElementCollection<StaffDetails> StaffDetails
        {
            get => _staffDetails ?? (_staffDetails = new ElementCollection<StaffDetails>());
            set => _staffDetails = value;
        }

        [XmlElement(ElementName = "transpose", Type = typeof(Transpose))]
        public ElementCollection<Transpose> Transposes
        {
            get => _transposes ?? (_transposes = new ElementCollection<Transpose>());
            set => _transposes = value;
        }

        [XmlElement(ElementName = "directive", DataType = "string")]
        public ElementCollection<string> Directives
        {
            get => _directives ?? (_directives = new ElementCollection<string>());
            set => _directives = value;
        }

        [XmlElement(ElementName = "measure-style", Type = typeof(MeasureStyle))]
        public ElementCollection<MeasureStyle> MeasureStyles
        {
            get => _measureStyles ?? (_measureStyles = new ElementCollection<MeasureStyle>());
            set => _measureStyles = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Attributes);
        }

        protected bool Equals(Attributes other)
        {
            return
                EqualityComparer<FormattedText>.Default.Equals(Footnote, other.Footnote) &&
                EqualityComparer<Level>.Default.Equals(Level, other.Level) &&
                EqualityComparer<PositiveDivisions>.Default.Equals(Divisions, other.Divisions) &&
                EqualityComparer<ElementCollection<Key>>.Default.Equals(Keys, other.Keys) &&
                EqualityComparer<ElementCollection<Time>>.Default.Equals(Times, other.Times) &&
                string.Equals(Staves, other.Staves) &&
                EqualityComparer<PartSymbol>.Default.Equals(PartSymbol, other.PartSymbol) &&
                string.Equals(Instruments, other.Instruments) &&
                EqualityComparer<ElementCollection<Clef>>.Default.Equals(Clefs, other.Clefs) &&
                EqualityComparer<ElementCollection<StaffDetails>>.Default.Equals(StaffDetails, other.StaffDetails) &&
                EqualityComparer<ElementCollection<Transpose>>.Default.Equals(Transposes, other.Transposes) &&
                EqualityComparer<ElementCollection<string>>.Default.Equals(Directives, other.Directives) &&
                EqualityComparer<ElementCollection<MeasureStyle>>.Default.Equals(MeasureStyles, other.MeasureStyles);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Footnote != null ? Footnote.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Level != null ? Level.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Divisions != null ? Divisions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Keys != null ? Keys.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Times != null ? Times.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Staves != null ? Staves.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PartSymbol != null ? PartSymbol.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Instruments != null ? Instruments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Clefs != null ? Clefs.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StaffDetails != null ? StaffDetails.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Transposes != null ? Transposes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Directives != null ? Directives.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MeasureStyles != null ? MeasureStyles.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}