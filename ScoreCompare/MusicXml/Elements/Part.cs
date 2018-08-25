using System.Collections.Generic;
using System.Xml.Serialization;

namespace ScoreCompare.MusicXml.Elements
{
    public class Part
    {
        private ElementCollection<Measure> _measures;

        [XmlAttribute(AttributeName = "id",DataType = "IDREF")]
        public string Id { get; set; }

        [XmlElement(ElementName = "measure",Type=typeof(Measure))]
        public ElementCollection<Measure> Measures
        {
            get => _measures ?? (_measures = new ElementCollection<Measure>());
            set => _measures = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Part);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (Measures != null ? Measures.GetHashCode() : 0);
            }
        }

        public bool Equals(Part obj)
        {
            return obj != null &&
                   Id == obj.Id &&
                   EqualityComparer<ElementCollection<Measure>>.Default.Equals(Measures, obj.Measures);
        }

    }
}