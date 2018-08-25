using System.Collections.Generic;
using System.Xml.Serialization;

namespace ScoreCompare.MusicXml.Elements
{
    public class Measure
    {
        private ElementCollection<Attributes> _attributes;
        private ElementCollection<Backup> _backups;
        private ElementCollection<Barline> _barlines;
        private ElementCollection<Bookmark> _bookmarks;
        private ElementCollection<Direction> _directions;
        private ElementCollection<FiguredBass> _figuredBasses;
        private ElementCollection<Forward> _forwards;
        private ElementCollection<Grouping> _groupings;
        private ElementCollection<Harmony> _harmonies;
        private ElementCollection<Link> _links;
        private ElementCollection<Note> _notes;
        private ElementCollection<Print> _prints;
        private ElementCollection<Sound> _sounds;

        [XmlAttribute(AttributeName = "number",DataType = "token")]
        public string Number { get; set; }

        [XmlAttribute(AttributeName = "implicit")]
        public YesNo Implicit { get; set; }

        [XmlIgnore]
        public bool ImplicitSpecified { get; set; }

        [XmlAttribute(AttributeName = "non-controlling")]
        public YesNo NonControlling { get; set; }

        [XmlIgnore]
        public bool NonControllingSpecified { get; set; }

        /// <remarks>Type is 'tenths' in musicXML.</remarks>
        [XmlAttribute(AttributeName = "width")]
        public double Width { get; set; }

        [XmlIgnore]
        public bool WidthSpecified { get; set; }

        [XmlElement(ElementName = "attributes",Type = typeof(Attributes))]
        public ElementCollection<Attributes> Attributes
        {
            get => _attributes ?? (_attributes = new ElementCollection<Attributes>());
            set => _attributes = value;
        }

        [XmlElement(ElementName = "backup", Type = typeof(Backup))]
        public ElementCollection<Backup> Backups
        {
            get => _backups ?? (_backups = new ElementCollection<Backup>());
            set => _backups = value;
        }

        [XmlElement(ElementName = "barline", Type = typeof(Barline))]
        public ElementCollection<Barline> Barlines
        {
            get => _barlines ?? (_barlines = new ElementCollection<Barline>());
            set => _barlines = value;
        }

        [XmlElement(ElementName = "bookmark", Type = typeof(Bookmark))]
        public ElementCollection<Bookmark> Bookmarks
        {
            get => _bookmarks ?? (_bookmarks = new ElementCollection<Bookmark>());
            set => _bookmarks = value;
        }

        [XmlElement(ElementName = "direction", Type = typeof(Direction))]
        public ElementCollection<Direction> Directions
        {
            get => _directions ?? (_directions = new ElementCollection<Direction>());
            set => _directions = value;
        }

        [XmlElement(ElementName = "figured-bass", Type = typeof(FiguredBass))]
        public ElementCollection<FiguredBass> FiguredBasses
        {
            get => _figuredBasses ?? (_figuredBasses = new ElementCollection<FiguredBass>());
            set => _figuredBasses = value;
        }

        [XmlElement(ElementName = "forward", Type = typeof(Forward))]
        public ElementCollection<Forward> Forwards
        {
            get => _forwards ?? (_forwards = new ElementCollection<Forward>());
            set => _forwards = value;
        }

        [XmlElement(ElementName = "grouping", Type = typeof(Grouping))]
        public ElementCollection<Grouping> Groupings
        {
            get => _groupings ?? (_groupings = new ElementCollection<Grouping>());
            set => _groupings = value;
        }

        [XmlElement(ElementName = "harmony", Type = typeof(Harmony))]
        public ElementCollection<Harmony> Harmonies
        {
            get => _harmonies ?? (_harmonies = new ElementCollection<Harmony>());
            set => _harmonies = value;
        }

        [XmlElement(ElementName = "link", Type = typeof(Link))]
        public ElementCollection<Link> Links
        {
            get => _links ?? (_links = new ElementCollection<Link>());
            set => _links = value;
        }

        [XmlElement(ElementName = "note", Type = typeof(Note))]
        public ElementCollection<Note> Notes
        {
            get => _notes ?? (_notes = new ElementCollection<Note>());
            set => _notes = value;
        }

        [XmlElement(ElementName = "print", Type = typeof(Print))]
        public ElementCollection<Print> Prints
        {
            get => _prints ?? (_prints = new ElementCollection<Print>());
            set => _prints = value;
        }

        [XmlElement(ElementName = "sound", Type = typeof(Sound))]
        public ElementCollection<Sound> Sounds
        {
            get => _sounds ?? (_sounds = new ElementCollection<Sound>());
            set => _sounds = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Measure);
        }

        protected bool Equals(Measure obj)
        {
            return 
                obj != null &&
                EqualityComparer<ElementCollection<Attributes>>.Default.Equals(Attributes, obj.Attributes) &&
                EqualityComparer<ElementCollection<Backup>>.Default.Equals(Backups, obj.Backups) &&
                EqualityComparer<ElementCollection<Barline>>.Default.Equals(Barlines, obj.Barlines) &&
                EqualityComparer<ElementCollection<Bookmark>>.Default.Equals(Bookmarks, obj.Bookmarks) &&
                EqualityComparer<ElementCollection<Direction>>.Default.Equals(Directions, obj.Directions) &&
                EqualityComparer<ElementCollection<FiguredBass>>.Default.Equals(FiguredBasses, obj.FiguredBasses) &&
                EqualityComparer<ElementCollection<Forward>>.Default.Equals(Forwards, obj.Forwards) &&
                EqualityComparer<ElementCollection<Grouping>>.Default.Equals(Groupings, obj.Groupings) &&
                EqualityComparer<ElementCollection<Harmony>>.Default.Equals(Harmonies, obj.Harmonies) &&
                EqualityComparer<ElementCollection<Link>>.Default.Equals(Links, obj.Links) &&
                EqualityComparer<ElementCollection<Note>>.Default.Equals(Notes, obj.Notes) &&
                EqualityComparer<ElementCollection<Print>>.Default.Equals(Prints, obj.Prints) &&
                EqualityComparer<ElementCollection<Sound>>.Default.Equals(Sounds, obj.Sounds) &&
                EqualityComparer<string>.Default.Equals(Number, obj.Number) &&
                Implicit == obj.Implicit &&
                ImplicitSpecified == obj.ImplicitSpecified &&
                NonControlling == obj.NonControlling &&
                NonControllingSpecified == obj.NonControllingSpecified &&
                EqualityComparer<double>.Default.Equals(Width, obj.Width) &&
                WidthSpecified == obj.WidthSpecified;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_attributes != null ? _attributes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_backups != null ? _backups.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_barlines != null ? _barlines.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_bookmarks != null ? _bookmarks.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_directions != null ? _directions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_figuredBasses != null ? _figuredBasses.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_forwards != null ? _forwards.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_groupings != null ? _groupings.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_harmonies != null ? _harmonies.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_links != null ? _links.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_notes != null ? _notes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_prints != null ? _prints.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_sounds != null ? _sounds.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Number != null ? Number.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Implicit;
                hashCode = (hashCode * 397) ^ ImplicitSpecified.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) NonControlling;
                hashCode = (hashCode * 397) ^ NonControllingSpecified.GetHashCode();
                hashCode = (hashCode * 397) ^ Width.GetHashCode();
                hashCode = (hashCode * 397) ^ WidthSpecified.GetHashCode();
                return hashCode;
            }
        }
    }
}