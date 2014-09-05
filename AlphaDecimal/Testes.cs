using NUnit.Framework;

namespace AlphaDecimal.Console
{
    [TestFixture]
    public class Testes
    {
        [TestCase("Z", 35)]
        [TestCase("A", 10)]
        [TestCase("10", 36)]
        [TestCase("19", 45)]
        [TestCase("1Z", 71)]
        [TestCase("ZZZ", 46655)]
        public void ConvertToDecimal(string alphaStr, int alphaDecimal)
        {
            AlphaDecimal alpha = alphaStr;

            Assert.AreEqual(alphaDecimal, alpha);
        }

        [TestCase("1", "Z", 36)]
        [TestCase("9", "Z", 44)]
        [TestCase("A", "Z", 45)]
        [TestCase("Z", "Z", 70)]
        public void SumToDecimal(string alphaStr1, string alphaStr2, int alphaDecimal)
        {
            AlphaDecimal alpha =  alphaStr1;
            AlphaDecimal alpha2 = alphaStr2;

            var aplhaDecimal = alpha + alpha2;

            Assert.AreEqual(alphaDecimal, aplhaDecimal);
        }

        [TestCase("1", "Z", "10")]
        [TestCase("9", "Z", "18")]
        [TestCase("A", "Z", "19")]
        [TestCase("Z", "Z", "1Y")]
        public void Sum(string alphaStr1, string alphaStr2, string alpha)
        {
            AlphaDecimal alpha1 = alphaStr1;
            AlphaDecimal alpha2 = alphaStr2;

            var aplhaDecimal = alpha1 + alpha2;

            Assert.AreEqual(alpha, aplhaDecimal.Value);
        }

        [TestCase(10, "A")]
        [TestCase(35, "Z")]
        public void TestToString(int alphaDecimal, string alphaStr)
        {
            AlphaDecimal alpha1 = alphaDecimal;

            Assert.AreEqual(alphaStr, alpha1.Value);
        }
    }
}
