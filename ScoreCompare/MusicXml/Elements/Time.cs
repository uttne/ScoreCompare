namespace ScoreCompare.MusicXml.Elements
{
    public class Time
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Time);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Time obj)
        {
            return obj != null;
        }
    }
}