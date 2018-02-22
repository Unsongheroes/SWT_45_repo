using System;

namespace RouletteGame.Legacy
{
    public interface IRandomizer
    {
        int Next(int n1, int n2);
    }

    public class Randomizer : IRandomizer
    {
        public int Next(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }

    public class FakeRandomizer : IRandomizer
    {
        public int Next(int n1, int n2)
        {
            return 1;
        }
    }
}