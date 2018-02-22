using NUnit.Framework;
using NUnit.Framework.Internal;
using RouletteGame.Legacy;

namespace RouletteGameTestSuite
{
    [TestFixture]
    public class RouletteTest
    {
        [Test]
        public void RouletteSpin()
        {
            var random = new FakeRandomizer();
            var uut = new Roulette(random);

            uut.Spin();

            Assert.That(uut.GetResult(), Is.EqualTo(new Field(1, Field.Red)));
        }
    }
}