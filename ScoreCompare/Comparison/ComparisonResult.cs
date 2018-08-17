namespace ScoreCompare.Comparison{
    public interface IComparisonResult<T>
    {
        IImmutableArray<T> Before { get; }
        IImmutableArray<T> After { get; }

        int Cost { get; }

        SesCollection<T> Ses { get; }
    }

    public readonly struct ComparisonResult<T> : IComparisonResult<T>
    {
        public ComparisonResult(IImmutableArray<T> before, IImmutableArray<T> after, int cost, SesCollection<T> ses)
        {
            Before = before;
            After = after;
            Cost = cost;
            Ses = ses;
        }

        public int Cost { get; }

        public IImmutableArray<T> Before { get; }

        public IImmutableArray<T> After { get; }

        public SesCollection<T> Ses { get; }
    }
}