namespace ScoreCompare.MusicXml.Elements
{
    public class PartSymbol
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as PartSymbol);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(PartSymbol obj)
        {
            return obj != null;
        }
    }
}