using Action;
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
    public partial class FindGamer : Form
    {
        public FindGamer()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FindGamer_Load(object sender, EventArgs e)
        {
            cleaning();
        }
        public void cleaning()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cleaning();
            if (textBox1.Text != null && textBox2.Text != null)
            {
                Action();
                textBox1.Text = null;
                textBox2.Text = null;
            }
            else
            {
                label7.Visible = true;
            }
        }

        public void Action()
        {
            List<List<string>> list = new List<List<string>>();
            GamerControl gc = new GamerControl();
            list = gc.FindGamer(textBox1.Text, textBox2.Text);

            ShowNames(list[0], list[1]);
            ShowSalaries(list[2]);
            ShowStatusForGame(list[3]);
            ShowStatusHealth(list[4]);
            ShowComand(list[5]);
        }

        public void ShowNames(List<string> list, List<string> lists)
        {
            if (list.Count != 0 && lists.Count!=0)
            {
                int j = 0;
                foreach (string i in list)
                {
                    listBox1.Items.Insert(j, i + " " + lists.ElementAt(j));
                    j++;
                }
            } 
            else
                listBox1.Items.Insert(0,"Не знайдено");
        }
        public void ShowSalaries(List<string> list)
        {
            if (list.Count != 0)
            {
                int j = 0;
                foreach (string i in list)
                {
                    listBox5.Items.Insert(j, i);
                    j++;
                }
            }
            else
                listBox5.Items.Insert(0, "Не знайдено");
        }
        public void ShowStatusForGame(List<string> list)
        {
            if (list.Count != 0)
            {
                int j = 0;
                foreach (string i in list)
                {
                    if (Convert.ToBoolean(i) == true)
                        listBox4.Items.Insert(j, "Грає");
                    else
                        listBox4.Items.Insert(j, "Не грає");
                    j++;
                }
            }
            else
                listBox4.Items.Insert(0, "Не знайдено");
        }
        public void ShowStatusHealth(List<string> list)
        {
            if (list.Count != 0)
            {
                int j = 0;
                foreach (string i in list)
                {
                    if (Convert.ToBoolean(i) == true)
                        listBox3.Items.Insert(j, "Здоровий");
                    else
                        listBox3.Items.Insert(j, "З вадами");
                    j++;
                }
            }
            else
                listBox3.Items.Insert(0, "Не знайдено");
        }
        public void ShowComand(List<string> list)
        {
            if (list.Count != 0)
            {
                int j = 0;
                foreach (string i in list)
                {
                    listBox2.Items.Insert(j, i);
                    j++;
                }
            }
            else
                listBox2.Items.Insert(0, "Не знайдено");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }
    }
}
