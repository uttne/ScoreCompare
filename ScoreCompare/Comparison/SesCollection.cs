using System.Collections;
using System.Collections.Generic;

namespace ScoreCompare.Comparison{

    public class SesCollection<TItme> :IImmutableArray<SesItem<TItme>>
    {
        private readonly List<SesItem<TItme>> _ses;

        internal SesCollection(List<SesItem<TItme>> ses)
        {
            _ses = ses;
        }

        public IEnumerator<SesItem<TItme>> GetEnumerator()
        {
            return _ses.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Length => _ses.Count;
        public SesItem<TItme> this[int index] => _ses[index];
    }
}