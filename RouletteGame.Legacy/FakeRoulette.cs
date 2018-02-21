namespace RouletteGame.Legacy
{
    public class FakeRoulette : IRoulette
    {
        public Field _result
        {
            set => _result = value;
            get => GetResult();
        }

        public bool SpinFuntionWasCalled { get; set; }
        public bool GetResultFuntionWasCalled { get; set; }

        public FakeRoulette()
        {
            SpinFuntionWasCalled = false;
            GetResultFuntionWasCalled = false;
        }

        public void Spin()
        {
            _result = new Field(1, Field.Red);
            SpinFuntionWasCalled = true;
        }

        public Field GetResult()
        {
            GetResultFuntionWasCalled = true;
            return _result;
        }
    }
}
