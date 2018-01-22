using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGame
{
    class Bullet : Base
    {
        public  Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            StarGame.Buffer.Graphics.DrawRectangle(
                Pens.OrangeRed, 
                pos_.X, 
                pos_.Y, 
                size_.Width, 
                size_.Height);
        }

        public override void Update()
        {
            pos_.X = pos_.X + 3;
        }    }
}
