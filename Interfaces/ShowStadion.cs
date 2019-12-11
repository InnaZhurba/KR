﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces
{
    public partial class ShowStadion : Form
    {
        public ShowStadion()
        {
            InitializeComponent();
        }

        private void ShowGamer_Load(object sender, EventArgs e)
        {
            listBox1.Text = null;
            Action.StadionControl gc = new Action.StadionControl();
            List<string> list = new List<string>();

            list = gc.ShowStadion();
            string[] lists = list.ToArray<string>();
            listBox1.Items.AddRange(lists);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
