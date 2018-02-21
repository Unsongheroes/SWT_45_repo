namespace RouletteGame.Legacy
{
    public interface IField
    {
        uint Number { get; }
        uint Color { get; }
        bool Even { get; }
        string ToString();
    }
}
