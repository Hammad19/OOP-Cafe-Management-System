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
    public partial class AdminUserDetails : Form1
    {
        public AdminUserDetails()
        {
            InitializeComponent();
        }

        private void AdminUserDetails_Load(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDetails(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminFoodManagment afm = new AdminFoodManagment();
            afm.FormClosed += (a, b) => this.Close();
            afm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome a1 = new AdminHome();
            a1.FormClosed += (a, b) => this.Close();
            a1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUserHistory auh = new AdminUserHistory();
            auh.FormClosed += (a, b) => this.Close();
            auh.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already On The Same Page");
        }
        Costumer coc = new Costumer();
                
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.

                

                    coc.CustomerID = Convert.ToInt32(row.Cells[0].Value);
                    coc.Firstname = row.Cells[1].Value.ToString();
                    coc.Lastname = row.Cells[2].Value.ToString();
                    coc.Gender = row.Cells[3].Value.ToString();
                    coc.City = row.Cells[4].Value.ToString();
                    coc.Country = row.Cells[5].Value.ToString();
                    coc.Email = row.Cells[6].Value.ToString();
                    coc.Date = row.Cells[7].Value.ToString();
                    coc.PhoneNumber = row.Cells[8].Value.ToString();
                    coc.Balance = Convert.ToInt32(row.Cells[9].Value);
                    
                   
                

                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            coc.UpdateCostumer();
            Console.WriteLine("Details Updated");
        }
    }
}
