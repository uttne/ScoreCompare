using System.Collections.Generic;
using System.Xml.Serialization;

namespace ScoreCompare.MusicXml.Elements
{
    [XmlRoot("score-partwise")]
    public class ScorePartwise
    {
        [XmlAttribute(AttributeName ="version",DataType ="token")]
        public string Version { get; set; }

        [XmlElement(ElementName = "work", Type = typeof(Work))]
        public Work Work { get; set; }

        [XmlElement(ElementName = "movement-number", DataType = "string")]
        public string MovementNumber { get; set; }

        [XmlElement(ElementName = "movement-title", DataType = "string")]
        public string MovementTitle { get; set; }

        [XmlElement(ElementName = "identification",Type = typeof(Identification))]
        public Identification Identification { get; set; }

        [XmlElement(ElementName = "defaults", Type = typeof(Defaults))]
        public Defaults Defaults { get; set; }

        [XmlElement(ElementName = "credit", Type =typeof(Credit))]
        public CreditCollection Credits { get; set; }

        [XmlElement(ElementName = "part-list", Type =typeof(PartList))]
        public PartList PartList { get; set; }

        [XmlElement(ElementName = "part",Type = typeof(Part))]
        public PartCollection Parts { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as ScorePartwise);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Version != null ? Version.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Work != null ? Work.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MovementNumber != null ? MovementNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MovementTitle != null ? MovementTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Identification != null ? Identification.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Defaults != null ? Defaults.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Credits != null ? Credits.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PartList != null ? PartList.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Parts != null ? Parts.GetHashCode() : 0);
                return hashCode;
            }
        }


        public bool Equals(ScorePartwise obj)
        {
            return obj != null &&
                   Version == obj.Version &&
                   EqualityComparer<Work>.Default.Equals(Work, obj.Work) &&
                   MovementNumber == obj.MovementNumber &&
                   MovementTitle == obj.MovementTitle &&
                   EqualityComparer<Identification>.Default.Equals(Identification, obj.Identification) &&
                   EqualityComparer<Defaults>.Default.Equals(Defaults, obj.Defaults) &&
                   EqualityComparer<CreditCollection>.Default.Equals(Credits, obj.Credits) &&
                   EqualityComparer<PartList>.Default.Equals(PartList, obj.PartList) &&
                   EqualityComparer<PartCollection>.Default.Equals(Parts, obj.Parts);
        }

    }
}
