using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StarGame
{
    class RepairKit : Base
    {
        public RepairKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public int Repair
        {
            get { return 10; }
        }

        public int FullHull()
        {
            return 100;
        }

        public override void Draw()
        {
            StarGame.Buffer.Graphics.FillEllipse(
               Brushes.Yellow,
               pos_.X,
               pos_.Y,
               size_.Width,
               size_.Height);
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
