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
    public partial class AboutUs : Form1
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderPlacement op = new OrderPlacement();
            op.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            History hs = new History();
            hs.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Accnt_Details ad = new Accnt_Details();
            ad.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AboutUs au = new AboutUs();
            au.Show();
            this.Hide();
        }
    }
}
