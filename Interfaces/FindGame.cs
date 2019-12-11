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
    public partial class FindGame : Form
    {
        public FindGame()
        {
            InitializeComponent();
        }

        private void FindGame_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FirstComands();
        }
        public void FirstComands()
        {
            List<string> list = new List<string>();
            GameControl game = new GameControl();
            list = game.CommandsReturning();
            foreach(string i in list)
            {
                comboBox1.Items.Add(i);
            }
        }
        public void Action()
        {
            List<string> list = new List<string>();
            List<string> res = new List<string>();
            GameControl game = new GameControl();
            list = game.ReturnValues(comboBox1.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), Convert.ToDateTime(comboBox2.SelectedItem));
            res = game.resultsreturningname(Convert.ToInt16(list.ElementAt(4)));
            listBox1.Items.Add("Стадіон: "+game.stadionreturningname(Convert.ToInt16(list.ElementAt(3)))+"; Кількість глядчів: "+ list.ElementAt(5)+
                "; Результат: "+(Convert.ToBoolean(res.ElementAt(0))?(Convert.ToBoolean(res.ElementAt(1))?"Нічия":("переможець - "+res.ElementAt(2))):("Гра не проведена")));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1 && comboBox3.SelectedIndex > -1)
            {
                listBox1.Items.Clear();
                Action();
            }            
            else
                listBox1.Items.Add("Помилка");
        }

        private void comboBox1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            List<string> list = new List<string>();
            GameControl game = new GameControl();
            list = game.DataForFirstComand(comboBox1.SelectedItem.ToString());
            foreach (string i in list)
            {
                comboBox2.Items.Add(i);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            List<string> list = new List<string>();
            GameControl game = new GameControl();
            list = game.SecondComandReturning(comboBox1.SelectedItem.ToString(), Convert.ToDateTime(comboBox2.SelectedItem.ToString()));
            comboBox3.Items.AddRange(list.ToArray());
            //foreach (string i in list)
            //{
            //    comboBox3.Items.Add(i);
            //}
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
