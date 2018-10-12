using System;
using System.Text;

namespace ScoreToSvg.Svg.Attributes
{
    public class Style
    {
        public Paint Fill { get; set; }
        public FillRule? FillRule { get; set; }
        public double? FillOpacity { get; set; } = 1d;

        private string ToStringFromFillRule(FillRule fillRule)
        {
            switch (fillRule)
            {
                case Attributes.FillRule.Nonzero: return "nonzero";
                case Attributes.FillRule.Evenodd: return "evenodd";
            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Fill != null)
            {
                sb.Append("fill:");
                sb.Append(Fill);
                if (FillRule != null)
                {
                    sb.Append(';');
                    sb.Append("fill-rule:");
                    sb.Append(ToStringFromFillRule(FillRule.Value));
                }
                if (FillOpacity != null)
                {
                    sb.Append(';');
                    sb.Append("fill-opacity:");
                    sb.Append(FillOpacity.Value);
                }
            }

            return sb.ToString();
        }
    }
}