namespace ScoreCompare.MusicXml.Elements
{
    public class Backup
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as Backup);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool Equals(Backup obj)
        {
            return obj != null;
        }
    }
}