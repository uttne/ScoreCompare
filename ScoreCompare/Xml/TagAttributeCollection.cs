using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScoreCompare.Xml
{
    public class TagAttributeCollection:ReadOnlyCollection<TagAttribute>
    {
        public TagAttributeCollection(IList<TagAttribute> list) : base(list)
        {
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TagAttributeCollection);
        }

        protected bool Equals(TagAttributeCollection other)
        {
            if (other == null)
                return false;

            if (Count != other.Count)
                return false;

            for(int i = 0;i < Count;i++)
                if(!EqualityComparer<TagAttribute>.Default.Equals(this[i] , other[i]))
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 0;
                for(int i = 0;i < Count;i++)
                    hashCode = (hashCode * 397) ^ (this[i] != null ? this[i].GetHashCode() : 0);

                return hashCode;
            }
        }
    }
}