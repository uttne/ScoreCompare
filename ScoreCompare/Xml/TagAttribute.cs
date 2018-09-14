namespace ScoreCompare.Xml
{
    public class TagAttribute
    {
        public string Name { get; }
        public string Text { get; }

        internal TagAttribute(string name,string text)
        {
            Name = name;
            Text = text;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TagAttribute);
        }

        protected bool Equals(TagAttribute other)
        {
            return 
                other != null &&
                string.Equals(Name, other.Name) && string.Equals(Text, other.Text);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Text != null ? Text.GetHashCode() : 0);
            }
        }
    }
}