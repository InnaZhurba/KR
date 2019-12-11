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
    public partial class ModifyGame : Form
    {
        public ModifyGame()
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
            if ((comboBox1.SelectedIndex > -1) && (comboBox4.SelectedIndex > -1) && (comboBox3.SelectedIndex > -1) && (comboBox5.SelectedIndex > -1) && (comboBox6.SelectedIndex > -1))
            {
                List<string> list = new List<string>();
                list = Diferences(comboBox4.SelectedItem.ToString());

                Action.GameControl gc = new Action.GameControl();
                int stadId = gc.FindIdStadion(comboBox2.SelectedItem.ToString());
                gc.ModifyResults(list.ElementAt(0), list.ElementAt(1), Convert.ToDateTime(listBox1.SelectedItem.ToString()),(checkBox1.Checked ? true : false)
                    , (checkBox1.Checked ? (checkBox2.Checked ? true : false) : (checkBox2.Checked = false)), comboBox3.SelectedItem.ToString(), comboBox6.SelectedItem.ToString());
                gc.ModifyGame(list.ElementAt(0), list.ElementAt(1), comboBox1.SelectedItem.ToString(), comboBox5.SelectedItem.ToString(), stadId, dateTimePicker1.Value, Convert.ToInt32(numericUpDown1.Value));
                this.Hide();
            }
            else
                label7.Visible = true;
        }
        public List<string> Diferences(string text)
        {
            List<string> list = new List<string>();
            string[] words = text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int j = 0;
            foreach (string s in words)
            {
                list.Insert(j, s);
                j++;
            }
            return list;
        }
        private void ModifyGamer_Load(object sender, EventArgs e)
        {
            ShowInComboBox();
            AddValues();
        }
        public void AddValues()
        {
            Action.GameControl gc = new Action.GameControl();
            List<string> st = new List<string>();

            st = gc.CommandsReturning();
            int j = 0;
            foreach (string i in st)
            {
                comboBox1.Items.Insert(j, i);
                comboBox5.Items.Insert(j, i);
                j++;
            }

            st.Clear();
            st = gc.StadionReturning();
            j = 0;
            foreach (string i in st)
            {
                comboBox2.Items.Insert(j, i);
                j++;
            }
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
            listBox1.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Visible = true;
                label6.Visible = true;
                label9.Visible = true;
                comboBox3.Visible = true;
                comboBox6.Visible = true;
            }
            else
            {
                checkBox2.Visible = false;
                label6.Visible = false;
                label9.Visible = false;
                comboBox3.Visible = false;
                comboBox6.Visible = false;

                checkBox2.Checked = false;
                comboBox3.SelectedIndex = 0;
                comboBox6.SelectedIndex = 1;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a, b;
            // повернення значень гравця в поля для зміни
            List<string> list = new List<string>();
            list = Diferences(comboBox4.SelectedItem.ToString());//визначаємо gamers names

            Action.GameControl gm = new Action.GameControl();
            List<string> values = new List<string>();
            values = gm.ReturnValues(list.ElementAt(0), list.ElementAt(1), Convert.ToDateTime(listBox1.SelectedItem.ToString()));
            if(values.Count!=0)
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString() == values.ElementAt(0))
                    {
                        comboBox1.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < comboBox5.Items.Count; i++)
                {
                    if (comboBox5.Items[i].ToString() == values.ElementAt(1))
                    {
                        comboBox5.SelectedIndex = i;
                    }
                }
                dateTimePicker1.Value = Convert.ToDateTime(values.ElementAt(2));
                numericUpDown1.Value = Convert.ToInt32(values.ElementAt(5));

                a = Convert.ToInt32(values.ElementAt(3));
                b = Convert.ToInt32(values.ElementAt(4));

                values.Clear();
                values = gm.stadion(a);
                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    if (comboBox2.Items[i].ToString() == values.ElementAt(0))
                    {
                        comboBox2.SelectedIndex = i;
                    }
                }
                numericUpDown1.Maximum = Convert.ToInt32(values.ElementAt(1));

                values.Clear();
                values = gm.result(b);
                if (Convert.ToBoolean(values.ElementAt(0)) == true)
                {
                    checkBox1.Checked = true;
                    if (Convert.ToBoolean(values.ElementAt(1)) == true)
                        checkBox2.Checked = true;
                    else
                        checkBox2.Checked = false;
                }
                else
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                }
                for (int i = 0; i < comboBox3.Items.Count; i++)
                {
                    if (comboBox3.Items[i].ToString() == values.ElementAt(2))
                    {
                        comboBox3.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < comboBox6.Items.Count; i++)
                {
                    if (comboBox6.Items[i].ToString() == values.ElementAt(3))
                    {
                        comboBox6.SelectedIndex = i;
                    }
                }
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Insert(0, comboBox1.SelectedItem.ToString());
            comboBox6.Items.Insert(0, comboBox1.SelectedItem.ToString());
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Insert(1, comboBox5.SelectedItem.ToString());
            comboBox6.Items.Insert(1, comboBox5.SelectedItem.ToString());
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                checkBox2.Checked = false;
            }
        }
    }
}
