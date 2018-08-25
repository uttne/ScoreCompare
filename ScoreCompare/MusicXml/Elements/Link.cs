namespace ScoreCompare.MusicXml.Elements
{
    public class Link
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Link);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Link obj)
        {
            return obj != null;
        }

    }
}