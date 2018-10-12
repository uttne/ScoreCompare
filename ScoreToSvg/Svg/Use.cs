using System;
using System.Text;

namespace ScoreToSvg.Svg
{
    public class Use:SvgElement
    {
        private string _hrefId;

        public Use(IHasId element)
        {
            if(element == null)
                throw new ArgumentNullException(nameof(element));
            if(string.IsNullOrWhiteSpace(element.Id))
                throw new ArgumentException("There is no Id.");

            HrefId = element.Id;
        }

        public Use(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("There is no Id.");

            HrefId = id;
        }

        public string HrefId
        {
            get => _hrefId;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("There is no Id.");
                _hrefId = value;
            }
        }

        public double? X { get; set; }
        public double? Y { get; set; }

        public override string ToSvg()
        {
            var sb = new StringBuilder();

            sb.Append("<use");

            AddAttributeText(sb, "xlink:href", "#" + HrefId);
            if (X != null)
                AddAttributeText(sb, "x", X.Value.ToString());
            if (Y != null)
                AddAttributeText(sb, "y", Y.Value.ToString());
            sb.Append(" />");

            return sb.ToString();
        }
    }
}