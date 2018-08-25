namespace ScoreCompare.MusicXml.Elements
{
    public class Print
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Print);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Print obj)
        {
            return obj != null;
        }
    }
}