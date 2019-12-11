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
    public partial class DeleteGamer : Form
    {
        public DeleteGamer()
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
                List<string> list = new List<string>();
                list = Diferences(comboBox4.SelectedItem.ToString());//визначаємо ім'я і призвище обране в комбобоксі

                Action.GamerControl gc = new Action.GamerControl();
                gc.DeleteGamer(list.ElementAt(0), list.ElementAt(1));
                this.Hide();
            }
            else
                label7.Visible = true;
        }
        public List<string> Diferences(string text)
        {
            List<string> list = new List<string>();
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int j = 0;
            foreach (string s in words)
            {
                list.Insert(j, s);
                j++;
            }
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DeleteGamer_Load(object sender, EventArgs e)
        {
            ShowGemersInComboBox();
        }

        public void ShowGemersInComboBox()
        {
            Action.GamerControl gc = new Action.GamerControl();
            List<string> fnst = new List<string>();
            List<string> snst = new List<string>();
            fnst = gc.GamerFirstNameReturning();
            snst = gc.GamerSecondNameReturning();
            int j = 0;
            foreach (string i in fnst)
            {
                comboBox4.Items.Insert(j, i + " " + snst[j]);
                j++;
            }
        }
    }
}
