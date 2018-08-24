namespace ScoreCompare.MusicXml.Elements
{
    public class Work
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Work);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Work obj)
        {
            return obj != null;
        }
    }
}