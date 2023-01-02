using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Text.RegularExpressions;


namespace OOP_Project
{
    public partial class Registration : Form
    {
        Costumer u = new Costumer();
        ValidationsController validate = new ValidationsController();


        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Are You Sure?", "Exit", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Registration_Load_1(object sender, EventArgs e)
        {

            if (FormControls.updateinfo == "Yes")
            {
                groupBox1.Hide();
                groupBox2.Show();
                label24.Text = label24.Text + "         " + FormControls.Id;
            }
            else
            {
                Random rand = new Random();
                u.CustomerID = rand.Next(999, 9999);
                label9.Text = label9.Text + "         " + u.CustomerID;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            u.SetAllData(u.CustomerID.ToString(), textBox1.Text, textBox2.Text, radioButton1, radioButton2, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, dateTimePicker1);
            u.Registration();

            if (FormControls.registrationclose == "Yes")
            {
                this.Hide();
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            label24.Text = label24.Text + "         " + FormControls.Id;
            u.SetAllData(FormControls.Id, ufname.Text, ulname.Text, umale, ufemale, ucity.Text, ucountry.Text, uphone.Text, uemail.Text, dateTimePicker2);
            u.UpdateCostumer();

            if (FormControls.registrationclose == "Yes")
            {

                MessageBox.Show("Please Login Again With New Details");
                this.Hide();
                Login loginagain = new Login();
                loginagain.Show();

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tt(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            validate.IsName(textBox1, errorProvider1);
        }

        

        private void textBox2_Leave(object sender, EventArgs e)
        {
            validate.IsName(textBox2, errorProvider1);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            validate.IsNumber(textBox5, errorProvider1);
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            validate.IsEmail(textBox6, errorProvider1);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            validate.IsCity(textBox3, errorProvider1);
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            validate.IsCountry(textBox4, errorProvider1);
        }

        private void ufname_Leave(object sender, EventArgs e)
        {
            validate.IsName(ufname, errorProvider1);
        }

        private void ulname_Leave(object sender, EventArgs e)
        {
            validate.IsName(ulname, errorProvider1);
        }

        private void ucity_Leave(object sender, EventArgs e)
        {
            validate.IsCity(ucity, errorProvider1);
        }

        private void ucountry_Leave(object sender, EventArgs e)
        {
            validate.IsCountry(ucountry, errorProvider1);
        }

        private void uphone_Leave(object sender, EventArgs e)
        {
            validate.IsNumber(uphone, errorProvider1);
        }

        private void uemail_Leave(object sender, EventArgs e)
        {
            validate.IsEmail(uemail, errorProvider1);
        }
    }
}
