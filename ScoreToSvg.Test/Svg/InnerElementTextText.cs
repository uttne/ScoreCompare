using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreToSvg.Svg;
using ScoreToSvg.Svg.Attributes;

namespace ScoreToSvg.Test.Svg
{
    [TestClass]
    public class InnerElementTextText
    {
        [TestMethod]
        public void ToSvg_success()
        {
            var svgBuilder = new SvgBuilder();

            svgBuilder.SvgElements.Add(new Rectangle()
            {
                Width = 100,
                Height = 100,
                X = 0,Y = 0,
                Style = new Style()
                {
                    Fill = new Paint(255, 0, 0)
                }
            });
            svgBuilder.SvgElements.Add(new Rectangle()
            {
                Width = 100,
                Height = 100,
                X = 110,
                Y = 110,
                Style = new Style()
                {
                    Fill = new Paint(0, 255, 0)
                }
            });

            var svg = svgBuilder.ToSvg();

            var svgBuilder2 = new SvgBuilder()
            {
                SvgElements =
                {
                    new Symbol()
                    {
                        Id = "symbol",
                        SvgElements = { new InnerElementText(svg)}
                    },
                    new Use("symbol")
                    {
                        X = 10,
                        Y = 10,
                    }
                }
            };

            var svg2 = svgBuilder2.ToSvg();
            Console.WriteLine(svg2);
        }
    }
}