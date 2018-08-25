namespace ScoreCompare.MusicXml.Elements
{
    public class Bookmark
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Bookmark);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Bookmark obj)
        {
            return obj != null;
        }

    }
}