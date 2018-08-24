using System.Collections.Generic;

namespace ScoreCompare.MusicXml.Elements
{
    public class CreditCollection:List<Credit>
    {
        public CreditCollection()
        {

        }

        public CreditCollection(IEnumerable<Credit> collection) : base(collection)
        {

        }

        public CreditCollection(int capacity) : base(capacity)
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CreditCollection);
        }

        protected bool Equals(CreditCollection obj)
        {
            if (obj == null || Count != obj.Count)
                return false;
            
            var comaparer = EqualityComparer<Credit>.Default;
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
            var comaparer = EqualityComparer<Credit>.Default;
            for (int i = 0; i < Count; ++i)
            {
                hashCode = hashCode * -1521134295 + comaparer.GetHashCode(this[i]);
                hashCode = hashCode * -1521134295 + i.GetHashCode();
            }
            return hashCode;
        }
    }
}