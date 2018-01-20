using System.Drawing;
using System;

namespace StarGame
{
    class Coin : BaseObject
    {
        private Image image;

        public Coin(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            try
            {
                image = Image.FromFile("coin1.jpg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(
                image,
                pos_.X,
                pos_.Y,
                pos_.X + size_.Width,
                pos_.Y + size_.Height);
        }

        public override void Update()
        {
            pos_.X = pos_.X + dir_.X;

            if (pos_.X < 0)
            {
                pos_.X = Game.Width + size_.Width;
            }
        }
    }
}
