using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Project
{
    public partial class Home : Form1
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
            label3.Text="Hello "+FormControls.Username+". Here are some quick links for you to get started";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Accnt_Details ad = new Accnt_Details();
            ad.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderPlacement o = new OrderPlacement();
            o.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            History hs = new History();
            hs.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AboutUs au = new AboutUs();
            au.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FoodFactory foodfactory = new FoodFactory();
            foodfactory.CreateFoodItem(radioButton1,radioButton2,radioButton3,radioButton4,radioButton5);
            this.Hide();
            OrderPlacement op = new OrderPlacement();
            op.FormClosed += (a, b) => this.Close();
            op.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
