using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ScoreToSvg.Svg
{
    public class SvgBuilder:IEnumerable<SvgElement>
    {
        public double Width { get; set; } = 300;
        public double Height { get; set; } = 300;
        public SvgBuilder()
        {
        }

        public SvgBuilder(IEnumerable<SvgElement> elements) => SvgElements.AddRange(elements);

        public SvgElementCollection SvgElements { get; } = new SvgElementCollection();

        public string ToSvg()
        {
            var sb = new StringBuilder();
            sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' version='1.1' width='{Width}' height='{Height}'>");

            if (SvgElements != null)
                sb.Append(SvgElements.ToSvgElementsText());

            sb.Append("</svg>");
            return sb.ToString();
        }

        public void Add(SvgElement element) => SvgElements.Add(element);

        public IEnumerator<SvgElement> GetEnumerator()
        {
            return SvgElements.GetEnumerator();
        }

        public override string ToString()
        {
            return ToSvg();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
