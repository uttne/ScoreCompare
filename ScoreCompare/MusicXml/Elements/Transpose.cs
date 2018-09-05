namespace ScoreCompare.MusicXml.Elements
{
    public class Transpose
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Transpose);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Transpose obj)
        {
            return obj != null;
        }
    }
}