using System;

namespace Game.Scripts.Helpers
{
    public static class Randomizer
    {
        private static readonly Random rnd = new(1);

        public static int Next(int min, int max)
        {
            return rnd.Next(min, max);
        }

        public static int UpTo(int max)
        {
            return rnd.Next(0, max);
        }


    }
}