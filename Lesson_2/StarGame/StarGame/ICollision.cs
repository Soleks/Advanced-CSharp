using System.Drawing;

namespace StarGame
{
    internal interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}