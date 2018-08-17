using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreCompare.Comparison;

namespace ScoreCompare.Test.Comparison
{
    [TestClass]
    public class ComparatorTest
    {
        [TestMethod]
        public void Compare_success()
        {
            var target = new Comparator<char>();

            var result = target.Compare("aabcxyfzzg", "abcdefg");

            var answer = new (char c, SesOperation o)[]
            {
                ('a', SesOperation.Common),
                ('a', SesOperation.Delete),
                ('b', SesOperation.Common),
                ('c', SesOperation.Common),
                ('x', SesOperation.Delete),
                ('y', SesOperation.Delete),
                ('d', SesOperation.Add),
                ('e', SesOperation.Add),
                ('f', SesOperation.Common),
                ('z', SesOperation.Delete),
                ('z', SesOperation.Delete),
                ('g', SesOperation.Common),
            };

            Assert.AreEqual(result.Ses.Length,answer.Length);
            foreach (var valueTuple in result.Ses.Zip(answer,(x,y)=>(x,y)))
            {
                Assert.AreEqual(valueTuple.Item1.Value, valueTuple.Item2.c);
                Assert.AreEqual(valueTuple.Item1.SesOperation, valueTuple.Item2.o);
            }
        }
    }
}
