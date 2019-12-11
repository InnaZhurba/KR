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
    public partial class DeleteStadion : Form
    {
        public DeleteStadion()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox4.SelectedIndex > -1))
            {
                Action.StadionControl gc = new Action.StadionControl();
                gc.DeleteStadion(comboBox4.SelectedItem.ToString());
                this.Hide();
            }
            else
                label7.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DeleteGamer_Load(object sender, EventArgs e)
        {
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

        private void comboBox4_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }
    }
}
