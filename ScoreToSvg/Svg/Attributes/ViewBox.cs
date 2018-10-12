using System.Text;

namespace ScoreToSvg.Svg.Attributes
{
    public class ViewBox
    {
        public double MinX { get; set; }
        public double MinY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(MinX);
            sb.Append(' ');
            sb.Append(MinY);
            sb.Append(' ');
            sb.Append(Width);
            sb.Append(' ');
            sb.Append(Height);

            return sb.ToString();
        }
    }
}