using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreToSvg.Svg;
using ScoreToSvg.Svg.Attributes;

namespace ScoreToSvg.Test.Svg
{
    [TestClass]
    public class SvgBuilderTest
    {
        [TestMethod]
        public void ToSvg_success()
        {
            var svgBuilder = new SvgBuilder();
            svgBuilder.SvgElements.Add(new Rectangle(){Width = 100,Height = 100,Style = new Style(){Fill = new Paint(255,0,0)}});
            var svg = svgBuilder.ToSvg();

            Console.WriteLine(svg);
        }
    }
}
