namespace ScoreCompare.MusicXml.Elements
{
    public class Grouping
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Grouping);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Grouping obj)
        {
            return obj != null;
        }

    }
}