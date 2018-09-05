namespace ScoreCompare.MusicXml.Elements
{
    public class FormattedText
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as FormattedText);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(FormattedText obj)
        {
            return obj != null;
        }
    }
}