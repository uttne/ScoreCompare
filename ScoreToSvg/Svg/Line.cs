using System.Text;
using ScoreToSvg.Svg.Attributes;

namespace ScoreToSvg.Svg
{
    public class Line:SvgElement
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public Style Style { get; set; }

        public override string ToSvg()
        {
            var sb = new StringBuilder();

            sb.Append("<line");
            AddAttributeText(sb, "x1", X1.ToString());
            AddAttributeText(sb, "y1", Y1.ToString());
            AddAttributeText(sb, "x2", X2.ToString());
            AddAttributeText(sb, "y2", Y2.ToString());
            if(Style != null)
                AddAttributeText(sb,"style",Style.ToString());
            sb.Append(" >");

            return sb.ToString();
        }
    }
}