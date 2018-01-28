using System.Drawing;

namespace StarGame
{
    class Star : Base
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            StarGame.Buffer.Graphics.DrawLine(
                Pens.White, 
                pos_.X, 
                pos_.Y, 
                pos_.X + size_.Width, 
                pos_.Y + size_.Height);

            StarGame.Buffer.Graphics.DrawLine(
                Pens.White, 
                pos_.X + size_.Width,
                pos_.Y, pos_.X, 
                pos_.Y + size_.Height);
        }

        public override void Update()
        {
            pos_.X = pos_.X + dir_.X;

            if (pos_.X < 0)
            {
                pos_.X = StarGame.Width + size_.Width;
            }
        }
    }
}
