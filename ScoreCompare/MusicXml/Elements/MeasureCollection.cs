using System.Collections.Generic;

namespace ScoreCompare.MusicXml.Elements
{
    public class MeasureCollection : List<Measure>
    {
        public MeasureCollection()
        {

        }

        public MeasureCollection(IEnumerable<Measure> collection) : base(collection)
        {

        }

        public MeasureCollection(int capacity) : base(capacity)
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MeasureCollection);
        }

        protected bool Equals(MeasureCollection obj)
        {
            if (obj == null || Count != obj.Count)
                return false;

            var comaparer = EqualityComparer<Measure>.Default;
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
            var comaparer = EqualityComparer<Measure>.Default;
            for (int i = 0; i < Count; ++i)
            {
                hashCode = hashCode * -1521134295 + comaparer.GetHashCode(this[i]);
                hashCode = hashCode * -1521134295 + i.GetHashCode();
            }
            return hashCode;
        }
    }
}