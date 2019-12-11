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
    public partial class DeleteGame : Form
    {
        public DeleteGame()
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


                Action.GameControl gc = new Action.GameControl();
                gc.DeleteGame(list.ElementAt(0), list.ElementAt(1), Convert.ToDateTime(listBox1.SelectedItem));
                this.Hide();
            }
            else
                label7.Visible = true;
        }
        public List<string> Diferences(string text)
        {
            List<string> list = new List<string>();
            string[] words = text.Split(new char[] { '-'}, StringSplitOptions.RemoveEmptyEntries);
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
            ShowInComboBox();
            listBox1.Text = null;
        }

        public void ShowInComboBox()
        {
            Action.GameControl gc = new Action.GameControl();
            List<string> fnst = new List<string>();
            fnst = gc.CommandsNameReturning();
            int j = 0;
            foreach (string i in fnst)
            {
                comboBox4.Items.Insert(j, i);
                j++;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listBox1.Text = null;
            Action.GameControl gc = new Action.GameControl();
            List<string> fnst = new List<string>();
            List<string> list = new List<string>();
            list = Diferences(comboBox4.SelectedItem.ToString());
            fnst = gc.DataReturning(list.ElementAt(0), list.ElementAt(1));
            int j = 0;
            foreach (string i in fnst)
            {
                listBox1.Items.Insert(j, i);
                j++;
            }
        }
    }
}
