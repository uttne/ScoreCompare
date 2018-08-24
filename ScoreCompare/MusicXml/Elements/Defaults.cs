namespace ScoreCompare.MusicXml.Elements
{
    public class Defaults
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Defaults);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Defaults obj)
        {
            return obj != null;
        }

    }
}