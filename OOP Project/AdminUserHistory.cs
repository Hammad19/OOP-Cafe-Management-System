using BusinessLogicLayer;
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
    public partial class AdminUserHistory : Form1
    {
        public AdminUserHistory()
        {
            InitializeComponent();
        }

        private void AdminUserHistory_Load(object sender, EventArgs e)
        {
            AdminControls add = new AdminControls();
            add.AddUserIDtoCombobox(comboBox1);
            OrderedItems od = new OrderedItems(comboBox1.SelectedItem.ToString());
            od.CountNumberofOrders();
            od.CountEach();
            ordercount.Text = od.COUNTORDERS.ToString();
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already On The Page");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminFoodManagment afm = new AdminFoodManagment();
            afm.FormClosed += (a, b) => this.Close();
            afm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUserDetails aud = new AdminUserDetails();
            aud.FormClosed += (a, b) => this.Close();
            aud.Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Admin admin = Admin.GetInstance("adm123");
            if (comboBox1.SelectedItem.ToString() == "ALL")
            {
                dataGridView1.Rows.Clear();
                admin.UserHistory(dataGridView1);
                OrderedItems od = new OrderedItems();
                od.CountNumberofOrders();
                ordercount.Text = od.COUNTORDERS.ToString();
                od.CountEach();
                od.ShowCount(fries, bg, pizza, sandwich, colddrink);
            }
            else
            {
                dataGridView1.Rows.Clear();
                Costumer cos = new Costumer();
                cos.UserHistory(dataGridView1, comboBox1.SelectedItem.ToString());

                OrderedItems odx = new OrderedItems(comboBox1.SelectedItem.ToString());
                odx.CountEach(comboBox1.SelectedItem.ToString());
                odx.ShowCount(fries, bg, pizza, sandwich, colddrink);
                ordercount.Text = odx.COUNTORDERS.ToString();
                
               
            }

            
            
        }
    }
}
