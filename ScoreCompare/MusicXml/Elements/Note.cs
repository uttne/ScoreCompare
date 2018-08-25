namespace ScoreCompare.MusicXml.Elements
{
    public class Note
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Note);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Note obj)
        {
            return obj != null;
        }

    }
}