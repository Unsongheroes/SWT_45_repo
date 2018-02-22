using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RouletteGame.Legacy;

namespace RouletteGameTestSuite
{
    [TestFixture]
    public class RouletteGameUnitTest
    {
        [Test]
        public void RouletteSpin()
        {
            var roulette = new FakeRoulette();
            var uut = new RouletteGame.Legacy.RouletteGame(roulette);

            uut.SpinRoulette();

            Assert.That(roulette.SpinFuntionWasCalled, Is.EqualTo(true));
        }

        [Test]
        public void RoulettePayUp_TestRouletteGetResult()
        {
            var roulette = new FakeRoulette();
            var uut = new RouletteGame.Legacy.RouletteGame(roulette);

            uut.PayUp();

            Assert.That(roulette.GetResultFuntionWasCalled, Is.EqualTo(true));
        }

        [Test]
        public void RouletteOpenBet()
        {
            var roulette = new FakeRoulette();
            var uut = new RouletteGame.Legacy.RouletteGame(roulette);

            uut.OpenBets();

            Assert.That(uut.RoundIsOpen, Is.EqualTo(true));
        }

        [Test]
        public void RouletteCloseBet()
        {
            var roulette = new FakeRoulette();
            var uut = new RouletteGame.Legacy.RouletteGame(roulette);

            uut.CloseBets();

            Assert.That(uut.RoundIsOpen, Is.EqualTo(false));
        }


        [Test]
        public void RoulettePayUp_TestBetWonAmount()
        {
            var roulette = new Roulette(new Randomizer());
            var uut = new RouletteGame.Legacy.RouletteGame(roulette);
            var fakeBet = new FakeBet("FakeBet", 100);

            uut.OpenBets();
            uut.PlaceBet(fakeBet);
            uut.PayUp();

            Assert.That(fakeBet.WonAmountWasCalled, Is.EqualTo(true));
        }

        [Test]
        public void RouletteFakeBetPlayerName()
        {
            var roulette = new Roulette(new Randomizer());
            var uut = new RouletteGame.Legacy.RouletteGame(roulette);
            var fakeBet = new FakeBet("FakeBet", 100);

            Assert.That(fakeBet.PlayerName, Is.EqualTo("FakeBet"));
        }

        [Test]
        public void RouletteFakeBetAmount()
        {
            var roulette = new Roulette(new Randomizer());
            var uut = new RouletteGame.Legacy.RouletteGame(roulette);
            var fakeBet = new FakeBet("FakeBet", 100);

            Assert.That(fakeBet.Amount, Is.EqualTo(100));
        }
    }
}
