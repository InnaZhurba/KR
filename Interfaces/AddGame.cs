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
    public partial class AddGame : Form
    {
        public AddGame()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameControl control = new GameControl();
            if ((comboBox1.SelectedIndex > -1) && (comboBox4.SelectedIndex > -1) && (comboBox3.SelectedIndex > -1) && (comboBox5.SelectedIndex > -1) && (comboBox6.SelectedIndex > -1))
            {
                int stadId = control.FindIdStadion(comboBox1.SelectedItem.ToString());
                int resultId = control.AddResults((checkBox1.Checked?true:false),(checkBox1.Checked?(checkBox2.Checked ? true : false):(checkBox2.Checked==false)), comboBox3.SelectedItem.ToString(), comboBox6.SelectedItem.ToString());
                control.AddGame(comboBox4.SelectedItem.ToString(), comboBox5.SelectedItem.ToString(), stadId, dateTimePicker1.Value, Convert.ToInt32(numericUpDown1.Value), resultId);
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
            AddValues();
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
            Action.GameControl gc = new Action.GameControl();
            List<string> st = new List<string>();

            st = gc.CommandsReturning();
            int j = 0;
            foreach (string i in st)
            {
                comboBox4.Items.Insert(j, i);
                comboBox5.Items.Insert(j, i);
                j++;
            }

            st.Clear();
            st = gc.StadionReturning();
            j = 0;
            foreach (string i in st)
            {
                comboBox1.Items.Insert(j, i);
                j++;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Action.GameControl gc = new Action.GameControl();
            int st;
            st = gc.MaxNumberOfViewers(comboBox1.SelectedItem.ToString());
            numericUpDown1.Maximum = st;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            comboBox3.Items.Insert(0, comboBox4.SelectedItem.ToString());
            comboBox6.Items.Insert(0, comboBox4.SelectedItem.ToString());
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox3.Items.Insert(1, comboBox5.SelectedItem.ToString());
            comboBox6.Items.Insert(1, comboBox5.SelectedItem.ToString());
        }
    }
}
