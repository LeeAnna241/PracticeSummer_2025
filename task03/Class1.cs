using System.Collections;
using System.Collections.Generic;

namespace task03
{
    public class CustomCollection<T> : IEnumerable<T>
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<T> GetReverseEnumerator()
        {
            int amount = _items.Count();
            for (var i = amount - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        public static IEnumerable<int> GenerateSequence(int start, int count)
        {
            for (var i = start; i < count + start; i++)
            {
                yield return i;
            }
        }

        public IEnumerable<T> FilterAndSort(Func<T, bool> predicate, Func<T, IComparable> keySelector)
        => _items
        .Where(predicate)
        .OrderBy(x => x);
    }
}