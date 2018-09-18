namespace ScoreCompare.Xml
{
    public class ClosingTag : Tag
    {
        public string Name { get; }

        internal ClosingTag(string syntaxText, string tagText,string name) : base(syntaxText, tagText)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ClosingTag);
        }

        protected bool Equals(ClosingTag other)
        {
            return
                other != null &&
                string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}