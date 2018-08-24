namespace ScoreCompare.MusicXml.Elements
{
    public class PartList
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as PartList);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(PartList obj)
        {
            return obj != null;
        }

    }
}