using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGame
{
    class Asteroid : Base
    {
        public  Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public int Power
        {
             get; set;        }

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
