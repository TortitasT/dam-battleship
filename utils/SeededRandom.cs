namespace dam_battleship.utils
{
    public class SeededRandom
    {
        private static System.Random _random = new();

        public static int Next(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static void SetSeed(int seed)
        {
            _random = new(seed);
        }
    }
}
