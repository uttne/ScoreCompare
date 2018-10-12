namespace ScoreToSvg.Svg.Attributes
{
    public class Paint
    {
        private readonly byte _r;
        private readonly byte _g;
        private readonly byte _b;

        public Paint(byte r, byte g, byte b)
        {
            _r = r;
            _g = g;
            _b = b;
        }

        public override string ToString()
        {
            return $"rgb({_r},{_g},{_b})";
        }
    }
}