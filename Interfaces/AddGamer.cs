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
    public partial class AddGamer : Form
    {
        public AddGamer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GamerControl control = new GamerControl();
            if((textBox1.Text != null)&&(textBox2.Text != null) && (comboBox1.SelectedIndex > -1) && (comboBox2.SelectedIndex > -1) && (textBox3.Text != null) && (comboBox3.SelectedIndex > -1))
            {
                control.AddGamer(textBox1.Text, textBox2.Text, Convert.ToBoolean(comboBox1.SelectedIndex), Convert.ToBoolean(comboBox2.SelectedIndex), Convert.ToDouble(textBox3.Text), comboBox3.SelectedItem.ToString());
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
            comboBox1.Items.Insert(0, "З вадами");
            comboBox1.Items.Insert(1, "Здоровий");

            comboBox2.Items.Insert(0, "Не грає");
            comboBox2.Items.Insert(1, "Грає");

            AddValues();

            //comboBox3.Items.Insert(0, "Dinamo");
            //comboBox3.Items.Insert(1, "Spartak");
            //comboBox3.Items.Insert(2, "Zara");
            //comboBox3.Items.Insert(3, "Libid");
           
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

        public void AddValues()
        {
            Action.GamerControl gc = new Action.GamerControl();
            List<string> st = new List<string>();
            st = gc.StadionReturning();
            int j = 0;
            foreach (string i in st)
            {
                comboBox3.Items.Insert(j, i);
                j++;
            }
        }
    }
}
