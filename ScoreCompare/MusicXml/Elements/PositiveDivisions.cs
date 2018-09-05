namespace ScoreCompare.MusicXml.Elements
{
    public class PositiveDivisions
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as PositiveDivisions);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(PositiveDivisions obj)
        {
            return obj != null;
        }
    }
}