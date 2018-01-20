using System;
using System.Drawing;
using System.Windows.Forms;

namespace SplashScreen
{
    class SplashScreen
    {
        private static BufferedGraphicsContext context_;
        private static BufferedGraphics _buffer;
        public static Base[] _objs;

        public static int Width { get; set; }
        public static int Height { get; set; }
        private static Random random = new Random();
        private static Player player;


        public static BufferedGraphics Buffer
        {
            get { return _buffer; }
        }

        public static Player Player
        {
            get{ return player; }    
        }

        public SplashScreen()
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

            _buffer = context_.Allocate(
                graphics, new Rectangle(0, 0, Width, Height));

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
            _buffer.Graphics.Clear(Color.Black);
            foreach (Base obj in _objs)
                obj.Draw();

            player.Draw();

            _buffer.Render();
        }

        public static void Update()
        {
            foreach (Base obj in _objs)
                obj.Update();
        }

        public static void Load()
        {
            _objs = new Base[30];

            player = new Player(new Point(Width/2, Height/2), new Point(10, 10), new Size(20,20));

            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = new Star(new Point(random.Next(Width), random.Next(Height)),
                   new Point(-3 * i, 0), new Size(2, 2));
            }
        }
    }
}
