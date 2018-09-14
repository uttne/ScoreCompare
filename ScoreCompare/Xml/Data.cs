namespace ScoreCompare.Xml
{
    public class Data : Syntax
    {
        public string Value { get; }

        public Data(string text, string value):base(text)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Data);
        }

        protected bool Equals(Data other)
        {
            return
                other != null &&
                string.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}