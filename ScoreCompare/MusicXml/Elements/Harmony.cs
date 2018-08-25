namespace ScoreCompare.MusicXml.Elements
{
    public class Harmony
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Harmony);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Harmony obj)
        {
            return obj != null;
        }

    }
}