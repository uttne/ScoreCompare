using System.Collections.Generic;

namespace ScoreCompare.Xml
{
    public class OpeningTag : Tag
    {
        private TagAttributeCollection _attributes;
        public string Name { get; }
        public TagAttributeCollection Attributes => _attributes ?? (_attributes = new TagAttributeCollection(new TagAttribute[0]));

        internal OpeningTag(string syntaxText, string tagText,string name, TagAttributeCollection attributes) :base(syntaxText,tagText)
        {
            Name = name;
            _attributes = attributes;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OpeningTag);
        }

        protected bool Equals(OpeningTag other)
        {
            return
                other != null &&
                string.Equals(Name, other.Name) &&
                EqualityComparer<TagAttributeCollection>.Default.Equals(Attributes, other.Attributes);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Attributes != null ? Attributes.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}