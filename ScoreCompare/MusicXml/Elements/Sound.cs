namespace ScoreCompare.MusicXml.Elements
{
    public class Sound
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Sound);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Sound obj)
        {
            return obj != null;
        }
    }
}