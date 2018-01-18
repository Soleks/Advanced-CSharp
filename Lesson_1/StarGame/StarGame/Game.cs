using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace StarGame
{
    static class Game
    {
        private static BufferedGraphicsContext context_;
        public static BufferedGraphics buffer;
        public static BaseObject[] _objs;

        public static int Width { get; set; }
        public static int Height { get; set; }
        private static Random random = new Random();


        static Game()
        {
        }      
        
        public static void Init(Form form)
        {
            Graphics graphics;

            form.Width = 800;
            form.Height = 600;
            random.Next(1, 100);

            context_ = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics();

            Width = form.Width;
            Height = form.Height;

            buffer = context_.Allocate(graphics, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();

            buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        public static void Load()
        {
            _objs = new BaseObject[30];
            //for (int i = 0; i < _objs.Length / 2; i++)
            //    _objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));

            for (int i = 0; i < _objs.Length; i++)
            {
                //   _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(5, 5));
                _objs[i] = new Star(new Point(random.Next(Width), random.Next(Height)),
                   new Point(-3 * i, 0), new Size(1, 1));
            }
        }
    }
}
