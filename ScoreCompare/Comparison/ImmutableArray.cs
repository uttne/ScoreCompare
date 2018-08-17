using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ScoreCompare.Comparison{
    public interface IImmutableArray<out T> : IEnumerable<T>
    {
        int Length { get; }
        T this[int index] { get; }
    }


    public class ImmutableArray<T>: IImmutableArray<T>
    {
        private readonly T[] _array;
        public int Length => _array.Length;

        public ImmutableArray(IEnumerable<T> source)
        {
            _array = source.ToArray();
        }

        public T this[int index] => _array[index];
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _array.Length; ++i)
                yield return _array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}