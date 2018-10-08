namespace ScoreCompare.Xml
{
    public class Tag:Syntax
    {
        public string TagText { get; }

        internal Tag(string syntaxText, string tagText):base(syntaxText)
        {
            TagText = tagText;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tag);
        }

        protected bool Equals(Tag other)
        {
            return
                other != null &&
                string.Equals(TagText, other.TagText);
        }

        public override int GetHashCode()
        {
            return (TagText != null ? TagText.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return TagText;
        }
    }
}
