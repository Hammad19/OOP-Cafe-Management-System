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
    public partial class AdminFoodManagment : Form1
    {
        AdminControls au = new AdminControls();
        Food foodop;

        public AdminFoodManagment()
        {
            InitializeComponent();
            //au.ShowFood(comboBox1.SelectedItem.ToString(), dataGridView1);
        }

        private void AdminFoodManagment_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foodop = new Food(); ;
            foodop.CATEGORY = comboBox1.SelectedItem.ToString();
            foodop.ShowFood(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foodop = new Food(comboBox1.SelectedItem.ToString(), textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text);
            foodop.UpFood();
            foodop.CATEGORY = comboBox1.SelectedItem.ToString();
            foodop.ShowFood(dataGridView1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome a1 = new AdminHome();
            a1.FormClosed += (a, b) => this.Close();
            a1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already On The Same Page");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foodop = new Food(comboBox1.SelectedItem.ToString(),textBox1.Text, textBox2.Text, textBox3.Text);
            foodop.AddFood( dataGridView1);
            foodop.CATEGORY = comboBox1.SelectedItem.ToString();
            foodop.ShowFood( dataGridView1);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("Item Sucessfully Added");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUserDetails aud = new AdminUserDetails();
            aud.FormClosed += (a, b) => this.Close();
            aud.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUserHistory auh = new AdminUserHistory();
            auh.FormClosed += (a, b) => this.Close();
            auh.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foodop = new Food(comboBox1.SelectedItem.ToString(), textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text);
            foodop.UpFood();
            foodop.CATEGORY = comboBox1.SelectedItem.ToString();
            foodop.ShowFood(dataGridView1);
            MessageBox.Show("Details Updated");
          
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        public void Crud(DataGridViewCellEventArgs e)
        {
            //Exception Lagni hai
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox4.Text = row.Cells[0].Value.ToString();
                textBox5.ReadOnly = true;
                textBox5.Text = row.Cells[1].Value.ToString();
                textBox7.Text = row.Cells[2].Value.ToString();
                textBox6.Text = row.Cells[3].Value.ToString();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foodop = new Food(textBox5.Text);
            foodop.DeleteFood();
            foodop.CATEGORY = comboBox1.SelectedItem.ToString();
            foodop.ShowFood(dataGridView1);
        }

        
    }
}
