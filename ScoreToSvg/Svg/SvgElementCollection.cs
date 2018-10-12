using System.Collections.Generic;
using System.Text;

namespace ScoreToSvg.Svg
{
    public class SvgElementCollection : List<SvgElement>
    {
        public string ToSvgElementsText()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Count; ++i)
            {
                var svgItem = this[i];
                if (svgItem == null)
                    continue;
                sb.Append(svgItem.ToSvg());
            }

            return sb.ToString();
        }
    }
}