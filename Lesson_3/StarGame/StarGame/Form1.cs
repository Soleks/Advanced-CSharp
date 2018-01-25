using System;
using System.Windows.Forms;

namespace StarGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //StarGame.Screen();
            label1.Hide();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StarGame.Init(this);
            label1.Show();
            label1_TextChanged(sender, e);
            //Form1_Load(sender, e);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            StarGame.Player.Direction(e);
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Oleksenko Sergey, demo version StarGame." +
                            "\r\nУпраление: \"стрелки\", огонь \"пробел\"");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
             StarGame.Player.Shot(e);
            label1_TextChanged(sender, e);
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            label1.Text ="Score: " + StarGame.Player.Score.ToString();
        }
    }
}
