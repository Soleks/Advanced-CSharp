﻿using System;
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
            Game.Init(this);
            Game.Draw();
        }
    }
}
