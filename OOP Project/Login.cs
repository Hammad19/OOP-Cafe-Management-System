using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Project
{
    public partial class Login : Form
    {

        Admin admin = Admin.GetInstance("adm123");
        
        public Login()
        {
            InitializeComponent();
             
        }

       

        

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            //WinAPI.AnimateWindow(this.Handle, 15000, WinAPI.CENTER);
            //timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login To Proceed");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login To Proceed");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login To Proceed");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login To Proceed");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Login To Proceed");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Login To Proceed");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Login To Proceed");
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Login To Proceed");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Are You Sure?", "Exit", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                timer1.Start();
            }
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration r1 = new Registration();
            r1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "admin") && (textBox4.Text == admin.AdminID))
            {
                FormControls.Id= textBox2.Text;
                admin.AdminID = textBox2.Text;
                this.Hide();
                AdminHome a1 = new AdminHome();
                a1.FormClosed += (a,b) => this.Close();
                a1.Show();
            }
            else
            {
                Costumer costumer = new Costumer();

                costumer.CustomerID = Convert.ToInt32(textBox4.Text);
                costumer.Firstname = textBox2.Text;
                costumer.Login();
                if (User.lgnfrm == 1)
                {
                    this.Hide();
                }
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 1)
            {
                this.Opacity += 0.025;
            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }
        }
        Validations validate = new Validations();
        private void textBox2_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            //validate.IsName(textBox2, errorProvider1);
        }
    }
}
