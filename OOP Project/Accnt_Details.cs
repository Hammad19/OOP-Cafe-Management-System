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
    public partial class Accnt_Details : Form1
    {
        public Accnt_Details()
        {
            InitializeComponent();
        }

        private void Accnt_Details_Load(object sender, EventArgs e)
        {
            Costumer u = new Costumer();
            u.GetDetails();
            u.ShowDetails(label3,label4,label5,label6,label7,label8,label9,label10,label11,label12);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration r1 = new Registration();
            FormControls.updateinfo = "Yes";
            r1.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {
            AboutUs au = new AboutUs();
            au.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
