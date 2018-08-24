namespace ScoreCompare.MusicXml.Elements
{
    public class Measure
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Measure);
        }

        protected bool Equals(Measure obj)
        {
            return obj != null;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}