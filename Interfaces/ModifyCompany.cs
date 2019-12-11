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
    public partial class ModifyCompany : Form
    {
        public ModifyCompany()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox4.SelectedIndex > -1) && (textBox1.Text != null) && (textBox2.Text != null) && (textBox3.Text != null))
            {
                string result;
                Action.StadionControl gc = new Action.StadionControl();
                result = gc.ModifyStadion(comboBox4.SelectedItem.ToString(), textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                label12.Text = result;
                this.Hide();
            }
            else
                label7.Visible = true;
        }
        private void ModifyGamer_Load(object sender, EventArgs e)
        {
            label12.Text = null;
            ShowInComboBox();
        }

        public void ShowInComboBox()
        {
            Action.StadionControl gc = new Action.StadionControl();
            List<string> fnst = new List<string>();
            fnst = gc.StadionNameReturning();
            int j = 0;
            foreach (string i in fnst)
            {
                comboBox4.Items.Insert(j, i);
                j++;
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // повернення значень гравця в поля для зміни
            Action.StadionControl gm = new Action.StadionControl();
            List<string> values = new List<string>();
            values = gm.ReturnValues(comboBox4.Text.ToString());

            textBox1.Text = values.ElementAt(0);
            textBox2.Text = values.ElementAt(1);
            textBox3.Text = values.ElementAt(2);
        }
    }
}
