namespace ScoreCompare.MusicXml.Elements
{
    public class Attributes
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Attributes);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Attributes obj)
        {
            return obj != null;
        }
    }
}