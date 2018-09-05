namespace ScoreCompare.MusicXml.Elements
{
    public class Key
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Key);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Key obj)
        {
            return obj != null;
        }
    }
}