namespace RouletteGame.Legacy
{
    public class FakeBet : Bet
    {
        public FakeBet(string name, uint amount) : base(name, amount)
        {
            PlayerName = name;
            Amount = amount;
        }

        public new string PlayerName { get; }
        public new uint Amount { get; }
        public bool WonAmountWasCalled { get; set; }

        public override uint WonAmount(Field field)
        {
            WonAmountWasCalled = true;
            return 1;
        }
    }
}