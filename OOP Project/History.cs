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
    public partial class History : Form1
    {
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            Admin admin = Admin.GetInstance("adm123");
            Costumer u = new Costumer();
            
            if (FormControls.Id == admin.AdminID)
            {
                admin.UserHistory(dataGridView1);
            }
            else
            {
                u.UserHistory(dataGridView1, FormControls.Id);

            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
