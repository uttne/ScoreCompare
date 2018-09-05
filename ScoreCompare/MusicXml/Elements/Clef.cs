namespace ScoreCompare.MusicXml.Elements
{
    public class Clef
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Clef);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Clef obj)
        {
            return obj != null;
        }
    }
}