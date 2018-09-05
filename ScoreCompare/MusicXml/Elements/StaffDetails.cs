namespace ScoreCompare.MusicXml.Elements
{
    public class StaffDetails
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as StaffDetails);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(StaffDetails obj)
        {
            return obj != null;
        }
    }
}