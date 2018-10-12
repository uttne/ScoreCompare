using System;
using System.Text.RegularExpressions;

namespace ScoreToSvg.Svg
{
    public class InnerElementText:SvgElement
    {
        private readonly Regex _innerElementRegex = new Regex("<svg.*?>(.*)</svg>", RegexOptions.Compiled);
        public InnerElementText(string svg)
        {
            if(svg == null)
                throw new ArgumentNullException(nameof(svg));

            var match = _innerElementRegex.Match(svg);
            if(!match.Success)
                throw new ArgumentException($"Argument is not svg text.");

            InnerText = match.Groups[1].Value;
        }

        public string InnerText { get; }

        public override string ToSvg()
        {
            return InnerText;
        }
    }
}