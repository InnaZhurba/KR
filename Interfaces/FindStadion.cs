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
    public partial class FindStadion : Form
    {
        public FindStadion()
        {
            InitializeComponent();
        }

        private void FindStadion_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ShowStadions();
        }
        public void ShowStadions()
        {
            List<string> list = new List<string>();
            StadionControl stadion = new StadionControl();
            list = stadion.StadionNameReturning();
            comboBox1.Items.AddRange(list.ToArray());
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> list = new List<string>();
            StadionControl stadion = new StadionControl();
            list = stadion.ShowStadionByName(comboBox1.SelectedItem.ToString());
            listBox1.Items.AddRange(list.ToArray());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
