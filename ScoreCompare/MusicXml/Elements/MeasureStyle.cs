namespace ScoreCompare.MusicXml.Elements
{
    public class MeasureStyle
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as MeasureStyle);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(MeasureStyle obj)
        {
            return obj != null;
        }
    }
}