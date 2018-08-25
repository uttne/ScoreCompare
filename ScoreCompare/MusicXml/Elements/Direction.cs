namespace ScoreCompare.MusicXml.Elements
{
    public class Direction
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Direction);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Direction obj)
        {
            return obj != null;
        }

    }
}