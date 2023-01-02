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

namespace OOP_Project
{
    public partial class AdminHome : Form1
    {
        Bill updatedelete;
        public AdminHome()
        {
            InitializeComponent();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

            AdminControls adminbhai = new AdminControls();
            adminbhai.AddUserIDtoCombobox(comboBox1);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminFoodManagment afm = new AdminFoodManagment();
            afm.FormClosed += (a, b) => this.Close();
            afm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already On The Same Page");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Admin admin = new Admin();
            //if (comboBox1.SelectedText == "ALL")
            //{
                
            //    admin.ShowBill(dataGridView1);
            //}
            //else
            //{
            //    admin.ShowBill(dataGridView1, comboBox1.SelectedText);
            //}
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Admin admin = Admin.GetInstance("adm123");
            if (comboBox1.SelectedItem.ToString() == "ALL")
            {
                dataGridView1.Rows.Clear();
                admin.ShowBill(dataGridView1);
            }
            else
            {
                dataGridView1.Rows.Clear();
                admin.ShowBill(dataGridView1, comboBox1.SelectedItem.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatedelete.updatebill();
            Admin admin = Admin.GetInstance("adm123");
            if ((comboBox1.SelectedItem.ToString() == "") || (comboBox1.SelectedItem.ToString() == "ALL"))
            {
                dataGridView1.Rows.Clear();
                admin.ShowBill(dataGridView1);
            }
            else
            {
                dataGridView1.Rows.Clear();
                admin.ShowBill(dataGridView1, comboBox1.SelectedItem.ToString());
            }
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                updatedelete = new Bill(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString());

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            updatedelete.deletebill();
            Admin admin = Admin.GetInstance("adm123");
            if (comboBox1.SelectedItem.ToString() == "ALL")
            {
                dataGridView1.Rows.Clear();
                admin.ShowBill(dataGridView1);
            }
            else
            {
                dataGridView1.Rows.Clear();
                admin.ShowBill(dataGridView1, comboBox1.SelectedItem.ToString());
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                updatedelete = new Bill(row.Cells[0].Value.ToString());
            }
        }
    }
}
