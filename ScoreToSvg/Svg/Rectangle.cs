using System.Text;
using ScoreToSvg.Svg.Attributes;

namespace ScoreToSvg.Svg
{
    public class Rectangle : SvgElement
    {
        public double? X { get; set; }
        public double? Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Style Style { get; set; }

        public override string ToSvg()
        {
            var sb = new StringBuilder();

            sb.Append("<rect");

            AddAttributeText(sb, "width", Width.ToString());
            AddAttributeText(sb, "height", Height.ToString());

            if (X != null)
                AddAttributeText(sb, "x", X.Value.ToString());
            if (Y != null)
                AddAttributeText(sb, "y", Y.Value.ToString());
            if (Style != null)
                AddAttributeText(sb, "style", Style.ToString());

            sb.Append("/>");

            return sb.ToString();
        }
    }
}