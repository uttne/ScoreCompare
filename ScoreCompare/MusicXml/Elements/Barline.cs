namespace ScoreCompare.MusicXml.Elements
{
    public class Barline
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Barline);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Barline obj)
        {
            return obj != null;
        }
    }
}