using System.Collections.Generic;

namespace ScoreCompare.MusicXml.Elements
{
    public class PartCollection : List<Part>
    {
        public PartCollection()
        {

        }

        public PartCollection(IEnumerable<Part> collection) : base(collection)
        {

        }

        public PartCollection(int capacity) : base(capacity)
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PartCollection);
        }

        protected bool Equals(PartCollection obj)
        {
            if (obj == null || Count != obj.Count)
                return false;

            var comaparer = EqualityComparer<Part>.Default;
            for (int i = 0; i < Count; ++i)
            {
                if (comaparer.Equals(this[i], obj[i]))
                    continue;
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 689873310;
            var comaparer = EqualityComparer<Part>.Default;
            for (int i = 0; i < Count; ++i)
            {
                hashCode = hashCode * -1521134295 + comaparer.GetHashCode(this[i]);
                hashCode = hashCode * -1521134295 + i.GetHashCode();
            }
            return hashCode;
        }
    }
}