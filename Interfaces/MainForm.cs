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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddGamer addGamer = new AddGamer();
            addGamer.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteGamer deleteGamer = new DeleteGamer();
            deleteGamer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModifyGamer modifyGamer = new ModifyGamer();
            modifyGamer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowGamer sg = new ShowGamer();
            sg.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddStadion addstadion = new AddStadion();
            addstadion.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteStadion deletestadion = new DeleteStadion();
            deletestadion.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ModifyCompany stadion = new ModifyCompany();
            stadion.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ShowStadion stadion = new ShowStadion();
            stadion.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddGame game = new AddGame();
            game.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeleteGame game = new DeleteGame();
            game.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyGame game = new ModifyGame();
            game.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowGame game = new ShowGame();
            game.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FindGamer gamer = new FindGamer();
            gamer.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FindGame game = new FindGame();
            game.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FindStadion stadion = new FindStadion();
            stadion.Show();
        }
    }
}
