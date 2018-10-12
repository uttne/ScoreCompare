using System.Collections;
using System.Collections.Generic;
using System.Text;
using ScoreToSvg.Svg.Attributes;

namespace ScoreToSvg.Svg
{
    public class Symbol : SvgElement,IEnumerable<SvgElement>, IHasId
    {

        public Symbol() { }
        public Symbol(IEnumerable<SvgElement> elements)
        {
            SvgElements.AddRange(elements);
        }

        public SvgElementCollection SvgElements { get; } = new SvgElementCollection();

        public string Id { get; set; }
        public ViewBox ViewBox { get; set; }
        public Style Style { get; set; }

        public override string ToSvg()
        {
            var sb = new StringBuilder();

            sb.Append("<symbol");
            if(Id != null)
                AddAttributeText(sb, "id", Id);
            if (ViewBox != null)
                AddAttributeText(sb, "viewBox", ViewBox.ToString());
            if (Style != null)
                AddAttributeText(sb, "style", Style.ToString());
            sb.Append(">");
            if (SvgElements != null)
                sb.Append(SvgElements.ToSvgElementsText());
            sb.Append("</symbol>");

            return sb.ToString();
        }

        public IEnumerator<SvgElement> GetEnumerator()
        {
            return SvgElements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(SvgElement element) => SvgElements.Add(element);
    }
}