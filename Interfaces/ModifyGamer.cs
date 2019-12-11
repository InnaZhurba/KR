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
    public partial class ModifyGamer : Form
    {
        public ModifyGamer()
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
            if ((comboBox4.SelectedIndex > -1)&&(textBox1.Text != null) && (textBox2.Text != null) && (comboBox1.SelectedIndex > -1) && (comboBox2.SelectedIndex > -1) && (textBox3.Text != null) && (comboBox3.SelectedIndex > -1))//textBox4.Text != null && textBox5.Text != null &&
            {
                string result;

                string[] a = new string[2];

                List<string> list = new List<string>();
                list = Diferences(comboBox4.SelectedItem.ToString());//визначаємо ім'я і призвище обране в комбобоксі
                int j = 0;
                foreach(string i in list)//дістаємо в 
                {
                    a[j] = i;
                    j++;
                }

                Action.GamerControl gc = new Action.GamerControl();
                result = gc.ModifyGamer(a[0],a[1],textBox1.Text, textBox2.Text, Convert.ToBoolean(comboBox1.SelectedIndex), Convert.ToBoolean(comboBox2.SelectedIndex), Convert.ToDouble(textBox3.Text), comboBox3.SelectedItem.ToString());
                //textBox5.Text, textBox4.Text, list[1],list[2]
                label12.Text = result;
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
            foreach(string s in words)
            {
                list.Insert(j,s);
                j++;
            }
            return list;
        }
        private void ModifyGamer_Load(object sender, EventArgs e)
        {
            label12.Text = null;

            comboBox1.Items.Insert(0, "З вадами");
            comboBox1.Items.Insert(1, "Здоровий");

            comboBox2.Items.Insert(0, "Не грає");
            comboBox2.Items.Insert(1, "Грає");

            ShowGemersInComboBox();

            AddValues();
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

        public void ShowGemersInComboBox()
        {
            Action.GamerControl gc = new Action.GamerControl();
            List<string> fnst = new List<string>();
            List<string> snst = new List<string>();
            fnst = gc.GamerFirstNameReturning();
            snst = gc.GamerSecondNameReturning();
            int j = 0;
            foreach(string i in fnst)
            {
                comboBox4.Items.Insert(j, i+" "+snst[j]);             
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
            List<string> list = new List<string>();
            list = Diferences(comboBox4.SelectedItem.ToString());//визначаємо ім'я і призвище обране в комбобоксі
            
            Action.GamerControl gm = new Action.GamerControl();
            List<string> values = new List<string>();
            values = gm.ReturnValues(list.ElementAt(0), list.ElementAt(1));

            textBox1.Text = list.ElementAt(0);
            textBox2.Text = list.ElementAt(1);
            textBox3.Text = values.ElementAt(2);

            if (Convert.ToBoolean(Convert.ToBoolean(values.ElementAt(4)) == false))
                comboBox1.SelectedIndex = 0;
            else
                comboBox1.SelectedIndex = 1;
            if (Convert.ToBoolean(Convert.ToBoolean(values.ElementAt(3))) == false)
                comboBox2.SelectedIndex = 0;
            else
                comboBox2.SelectedIndex = 1;
            for(int i=0;i<comboBox3.Items.Count;i++)
            {
                if (comboBox3.Items[i].ToString() == values.ElementAt(5))
                    comboBox3.SelectedIndex = i;
            }
            //comboBox3.SelectedItem = values.ElementAt(5);
        }
    }
}
