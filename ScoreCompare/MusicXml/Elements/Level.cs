namespace ScoreCompare.MusicXml.Elements
{
    public class Level
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Level);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Level obj)
        {
            return obj != null;
        }
    }
}