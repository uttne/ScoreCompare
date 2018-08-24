namespace ScoreCompare.MusicXml.Elements
{
    public class Credit
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Credit);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Credit obj)
        {
            return obj != null;
        }

    }
}