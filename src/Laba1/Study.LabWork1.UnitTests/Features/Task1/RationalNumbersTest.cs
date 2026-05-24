using System;
using NUnit.Framework;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    public class RationalNumberTest
    {
        [Test]
        public void SimpleFractionTest()
        {
            var fraction = new RationalNumber(1, 2);
            Assert.Multiple(() =>
            {
                Assert.That(fraction.Numerator, Is.EqualTo(1));
                Assert.That(fraction.Denominator, Is.EqualTo(2));
                Assert.That(fraction.ToString(), Is.EqualTo("1/2"));
            });
        }
    }
}
