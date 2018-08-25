namespace ScoreCompare.MusicXml.Elements
{
    public class FiguredBass
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as FiguredBass);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(FiguredBass obj)
        {
            return obj != null;
        }

    }
}