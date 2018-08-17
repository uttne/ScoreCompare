namespace ScoreCompare.Comparison{
    
    public enum SesOperation
    {
        Common,
        Add,
        Delete,
    }

    public interface ISesItem<out TItme>
    {
        TItme Value { get; }
        SesOperation SesOperation { get; }
    }

    public readonly struct SesItem<TItme> : ISesItem<TItme>
    {
        public SesItem(TItme value, SesOperation sesOperation)
        {
            Value = value;
            SesOperation = sesOperation;
        }

        public TItme Value { get; }
        public SesOperation SesOperation { get; }

        public override string ToString()
        {
            return $"Value : {Value} , SesOperation : {SesOperation}";
        }
    }
}