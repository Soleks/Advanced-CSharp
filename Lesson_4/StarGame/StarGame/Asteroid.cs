using System.Drawing;

namespace StarGame
{
    class Asteroid : Base
    {
        private static int countAsteroids = 0;

        public  Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public int Power
        {
             get; set;        }

        public static int Count
        {
            get
            {
                return countAsteroids;
            }        }

        public static void IncrementAsteroids()
        {
            countAsteroids++;
        }

        public override void Draw()
        {
            StarGame.Buffer.Graphics.FillEllipse(
                Brushes.Blue, 
                pos_.X, 
                pos_.Y, 
                size_.Width, 
                size_.Height);
        }
    }
}
