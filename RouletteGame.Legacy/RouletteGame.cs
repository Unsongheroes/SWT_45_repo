using System;
using System.Collections.Generic;

namespace RouletteGame.Legacy
{
    public class RouletteGame
    {
        private readonly List<IBet> _bets;
        private readonly IRoulette _roulette;
        //Udkommenteret for at gøre det testable - right?
        //private bool _roundIsOpen;
        public bool RoundIsOpen { get; private set; }

        public RouletteGame(IRoulette roulette)
        {
            _bets = new List<IBet>();
            _roulette = roulette;
        }

        public void OpenBets()
        {
            Console.WriteLine("Round is open for bets");
            RoundIsOpen = true;
        }

        public void CloseBets()
        {
            Console.WriteLine("Round is closed for bets");
            RoundIsOpen = false;
        }

        public void PlaceBet(IBet bet)
        {
            if (RoundIsOpen) _bets.Add(bet);
            else throw new RouletteGameException("Bet placed while round closed");
        }

        public void SpinRoulette()
        {
            Console.Write("Spinning...");
            _roulette.Spin();
            Console.WriteLine("Result: {0}", _roulette.GetResult());
        }

        public void PayUp()
        {
            var result = _roulette.GetResult();

            foreach (var bet in _bets)
            {
                var won = bet.WonAmount(result);
                if (won > 0)
                    Console.WriteLine("{0} just won {1}$ on a {2}", bet.PlayerName, won, bet);
            }
        }
    }

    public class RouletteGameException : Exception
    {
        public RouletteGameException(string s) : base(s)
        {
        }
    }
}