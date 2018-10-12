using System.Text;

namespace ScoreToSvg.Svg
{

    public class SvgElement
    {
        public virtual string ToSvg() => "";

        internal static void AddAttributeText(StringBuilder dest, string attributeName,string value)
        {
            dest.Append(' ');
            dest.Append(attributeName);
            dest.Append('=');
            dest.Append('\'');
            dest.Append(value);
            dest.Append('\'');
        }
    }
}