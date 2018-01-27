using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StarGame
{
    class StarGame
    {
        private static BufferedGraphicsContext context_;
        private static BufferedGraphics _buffer;
        public static Base[] _objs;
        private static Asteroid[] _asteroids;        private static RepairKit[] _rKit;
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static Random random = new Random();
        private static Player player;
        private static Image image;

        private static Log log;

        private static Timer timer = new Timer { Interval = 70 };

        public static BufferedGraphics Buffer
        {
            get { return _buffer; }
        }

        public static Player Player
        {
            get { return player; }
        }

        public StarGame()
        {
            
        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60,
            FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        public static void Screen()
        {
            try
            {
                image = Image.FromFile(@".\Pic\Image.png");

                StarGame.Buffer.Graphics.DrawImage(image, 0, 0);

            } catch (Exception e)
            {
                throw new Exception("Файл не найден {0}", e);
            }
        }

        private static void Message(object o, GameLogEventArgs message)
        {
            string logFile = (message.Type == "Info" ? @".\Log\LogInfo.txt" : 
                              message.Type == "Game event" ? @".\Log\LogGameEvent.txt" : 
                              string.Empty);

            if (!string.IsNullOrEmpty(logFile))
            {
                using (StreamWriter sw = new StreamWriter(logFile, true))
                {
                    DateTime date = DateTime.Now;

                    sw.WriteLine(date.ToString() + " " + message.Message);
                }
            }
            
            Console.WriteLine("{0}: {1}", message.Type , message.Message);
        }

        public static void Init(Form form)
        {
            Graphics graphics;

            log = new Log();

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
            log.WriteLogToConsole("Info", "initialization successful", Message);            Player.MessageDie += Finish; 
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
            {
                obj.Draw();
            }

            foreach (Asteroid obj in _asteroids)
            {
                obj.Draw();
            }

            foreach (RepairKit rk in _rKit)
            {
                rk.Draw();
            }

            player.Draw();
            Buffer.Graphics.DrawString("Energy:" + player.Energy, SystemFonts.DefaultFont, Brushes.White, 0,0);

            if (player.Bullet != null)
            {
                player.Bullet.Draw();
            }

            _buffer.Render();
        }

        public static void Update()
        {
            foreach (Base obj in _objs)
            {
                obj.Update();
            }

            foreach (RepairKit rk in _rKit)
            {
                rk.Update();
            }

            var rnd = new Random();

            for (int i = 0; i < _rKit.Length; i++)
            {
                if (player.Collision(_rKit[i]))
                {
                    log.WriteLogToConsole("Game event", "repear", Message);

                    var eTemp = player.Energy;

                    player.Energy = _rKit[i].Repair;

                    int r = rnd.Next(5, 50);
                    _rKit[i] = new RepairKit(
                               new Point(Width, rnd.Next(0, rnd.Next(0, Height))),
                               new Point(-r / 5, r),
                               new Size(r, r)); ;
                }
            }

            for (int i = 0; i < _asteroids.Length; i++)
            {
                _asteroids[i].Update();

                if (player.Bullet != null && 
                    player.Bullet.X >= Width)
                {
                    player.Bullet = null;
                }


                if (player.Collision(_asteroids[i]))
                {
                    var r = new Random();

                    log.WriteLogToConsole("Game event", "collision", Message);

                    player?.EnergyLow(r.Next(1,10));

                    Console.WriteLine(player.Energy);

                    if (player.Energy <= 0)
                    {
                        log.WriteLogToConsole("Game event", "starship destroy", Message);

                        player.Die();
                    }
                }

                if (player.Bullet != null &&
                    _asteroids[i].Collision(player.Bullet))
                {
                    player.Bullet = null;
                    int r = rnd.Next(5, 50);
                    _asteroids[i] = new Asteroid(
                        new Point(Width, rnd.Next(0, StarGame.Height)), 
                        new Point(-r / 5, r), 
                        new Size(r, r));

                    log.WriteLogToConsole("Game event", "hit", Message);

                    player.IncrementScore();
                }
             }

            if (player.Bullet != null)
            {
                player.Bullet.Update();
            }
        }

        private static void CreateRepairKit()
        {
            var rnd = new Random();

            for (int i = 0; i < _rKit.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _rKit[i] = new RepairKit(
                new Point(Width, rnd.Next(0, rnd.Next(0, Height))),
                new Point(-r / 5, r),
                new Size(r, r));
            }
        }

        public static void Load()
        {
            _rKit = new RepairKit[2];
            _objs = new Base[30];
            _asteroids = new Asteroid[3];
            var rnd = new Random();
            player = new Player(
                new Point(Width/2, Height/2), 
                new Point(10, 10), 
                new Size(20,20));

            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = new Star(new Point(random.Next(Width), random.Next(Height)),
                   new Point(-3 * i, 0), new Size(2, 2));
            }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(
                    new Point(Width, rnd.Next(0, StarGame.Height)), 
                    new Point(-r / 5, r), 
                    new Size(r, r));
            }            for (int i = 0; i < _rKit.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _rKit[i] = new RepairKit(
                    new Point(Width, rnd.Next(0, rnd.Next(0, Height))),
                    new Point(-r / 5, r),
                    new Size(r, r));
            }        }
    }
}
