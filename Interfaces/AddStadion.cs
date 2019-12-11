using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Action;

namespace Interfaces
{
    public partial class AddStadion : Form
    {
        public AddStadion()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StadionControl control = new StadionControl();
            if ((textBox1.Text != null) && (textBox2.Text != null) && (textBox3.Text != null))
            {
                control.AddStadion(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToSingle(textBox3.Text));
                this.Hide();
            }
            else
            {
                label7.Visible = true;
            }
        }

        private void AddGamer_Load(object sender, EventArgs e)
        {
            Action.GamerControl dc = new GamerControl();            
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }      
    }
}
