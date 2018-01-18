using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGame
{
    class Star :BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(
                Pens.White, 
                pos_.X, 
                pos_.Y, 
                pos_.X + size_.Width, 
                pos_.Y + size_.Height);

            Game.buffer.Graphics.DrawLine(
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
                pos_.X = Game.Width + size_.Width;
            }
        }
    }
}
