namespace ScoreCompare.MusicXml.Elements
{
    public class Part
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Part);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Part obj)
        {
            return obj != null;
        }

    }
}