using System;
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
    public partial class ShowGamer : Form
    {
        public ShowGamer()
        {
            InitializeComponent();
        }

        private void ShowGamer_Load(object sender, EventArgs e)
        {
            listBox1.Text = null;
            Action.GamerControl gc = new Action.GamerControl();
            List<string> list = new List<string>();
           
            list = gc.ShowGamer();
            string [] lists = list.ToArray<string>();
            listBox1.Items.AddRange(lists);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
