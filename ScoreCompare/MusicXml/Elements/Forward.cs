namespace ScoreCompare.MusicXml.Elements
{
    public class Forward
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Forward);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Forward obj)
        {
            return obj != null;
        }

    }
}