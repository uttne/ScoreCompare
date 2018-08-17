using System;
using System.Collections.Generic;

namespace ScoreCompare.Comparison{
    public interface IComparator<T>
    {
        IComparisonResult<T> Compare(IImmutableArray<T> before, IImmutableArray<T> after);
        IComparisonResult<T> Compare(IEnumerable<T> before, IEnumerable<T> after);
        IComparisonResult<T> Compare(T[] before, T[] after);
    }
    public class Comparator<T> : IComparator<T>
    {
        internal (int cost, SesCollection<T> ses) CalcCost(IImmutableArray<T> before, IImmutableArray<T> after)
        {
            var m = before.Length;
            var n = after.Length;
            var max = m + n;

            var v = new int[max * 2 + 1];

            var pos = new int[max * 2 + 1];
            var epc = new List<(int prev, int x, int y)>();

            var offset = max;
            // initial value of p when cost == 0 && k == 0
            pos[1 + offset] = -1;
            for (int cost = 0; cost <= max; cost++)
            {
                for (int k = -cost; k <= cost; k += 2)
                {
                    int y;
                    var ym1 = v[k - 1 + offset] + 1;
                    var yp1 = v[k + 1 + offset];

                    var pm1 = pos[k - 1 + offset];
                    var pp1 = pos[k + 1 + offset];
                    int p;
                    if (k == -cost)
                    {
                        y = yp1;
                        p = pp1;
                    }
                    else if (k == cost)
                    {
                        y = ym1;
                        p = pm1;
                    }
                    else if (ym1 < yp1)
                    {
                        y = yp1;
                        p = pp1;
                    }
                    else
                    {
                        y = ym1;
                        p = pm1;
                    }

                    var x = y - k;
                    while (x < m && y < n && Compare(before[x], after[y]))
                    {
                        ++x;
                        ++y;
                    }

                    pos[k + offset] = epc.Count;
                    epc.Add((p, x, y));

                    v[k + offset] = y;
                    if (x >= m && y >= n)
                    {
                        var ses = CalcSes(before, after, epc);
                        return (cost, ses);
                    }
                }
            }

            throw new NotImplementedException();
        }

        internal bool Compare(in T x,in T y)
        {
            if (x == null)
            {
                if (y == null)
                    return true;
                // boxing
                return y.Equals(x);
            }

            // boxing
            return x.Equals(y);
        }

        internal SesCollection<T> CalcSes(IImmutableArray<T> before, IImmutableArray<T> after, List<(int prev, int x, int y)> epc)
        {
            var ses = new List<SesItem<T>>();

            var item = epc[epc.Count - 1];

            while (0 <= item.prev)
            {
                var prev = epc[item.prev];

                int x = item.x, y = item.y;
                while (prev.x != x && prev.y != y)
                {
                    ses.Add(new SesItem<T>(before[x - 1], SesOperation.Common));

                    --x;
                    --y;
                }

                ses.Add(x == prev.x ? new SesItem<T>(after[y - 1], SesOperation.Add) : new SesItem<T>(before[x - 1], SesOperation.Delete));

                item = prev;
            }

            {
                int x = item.x, y = item.y;

                if (x == 0)
                {
                    ses.Add(new SesItem<T>(after[0], SesOperation.Add));
                }
                else if (y == 0)
                {
                    ses.Add(new SesItem<T>(before[0], SesOperation.Delete));
                }
                else
                {
                    while (0 < x)
                    {
                        ses.Add(new SesItem<T>(before[x - 1], SesOperation.Common));
                        --x;
                    }
                }
            }
            ses.Reverse();
            return new SesCollection<T>(ses);
        }

        public IComparisonResult<T> Compare(IImmutableArray<T> before, IImmutableArray<T> after)
        {
            var result = CalcCost(before, after);
            return new ComparisonResult<T>(before, after, result.cost, result.ses);
        }

        public IComparisonResult<T> Compare(IEnumerable<T> before, IEnumerable<T> after)
        {
            return Compare(new ImmutableArray<T>(before), new ImmutableArray<T>(after));
        }

        public IComparisonResult<T> Compare(T[] before, T[] after)
        {
            return Compare(new ImmutableArray<T>(before), new ImmutableArray<T>(after));
        }
    }
}