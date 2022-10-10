using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOP_Project
{
    public partial class OrderPlacement : Form1
    {
        public static bool sb = false;
        public OrderPlacement()
        {
            InitializeComponent();
        }

        CheckOutCart COC = new CheckOutCart();
        FoodItems FI = new FoodItems();

        private void OrderPlacement_Load(object sender, EventArgs e)
        {
            if (FormControls.QuickView!="")
            {
                comboBox1.SelectedText = FormControls.QuickView;


                if (FormControls.QuickView == "Pizza")
                {
                    FI.FileName = "PizzaItems";
                    FI.ShowList(comboBox2);
                    listBox1.Items.Clear();
                    COC.PriceShow(listBox1, comboBox1.Text.ToString());
                    pictureBox3.Visible = true;
                    COC.PicShow(pictureBox3, comboBox1.Text.ToString());
                }
                else if (FormControls.QuickView == "Burger")
                {
                    FI.FileName = "BurgerItems";
                    FI.ShowList(comboBox2);
                    listBox1.Items.Clear();
                    COC.PriceShow(listBox1, comboBox1.Text.ToString());
                    pictureBox3.Visible = true;
                    COC.PicShow(pictureBox3, comboBox1.Text.ToString());
                }
                else if (FormControls.QuickView == "Sandwiches")
                {
                    FI.FileName = "SandwichesItems";
                    FI.ShowList(comboBox2);
                    listBox1.Items.Clear();
                    COC.PriceShow(listBox1, comboBox1.Text.ToString());
                    pictureBox3.Visible = true;
                    COC.PicShow(pictureBox3, comboBox1.Text.ToString());
                }
                else if (FormControls.QuickView == "Fries")
                {
                    FI.FileName = "FriesItems";
                    FI.ShowList(comboBox2);
                    listBox1.Items.Clear();
                    COC.PriceShow(listBox1, comboBox1.Text.ToString());
                    pictureBox3.Visible = true;
                    COC.PicShow(pictureBox3, comboBox1.Text.ToString());
                }
                else if (FormControls.QuickView == "SoftDrinks")
                {
                    FI.FileName = "SoftDrinksitems";
                    FI.ShowList(comboBox2);
                    listBox1.Items.Clear();
                    COC.PriceShow(listBox1, comboBox1.Text.ToString());
                    pictureBox3.Visible = true;
                    COC.PicShow(pictureBox3, comboBox1.Text.ToString());
                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            FI.FileName = comboBox1.SelectedItem.ToString();
            if (comboBox1.SelectedItem.ToString() == "Pizza")
            {
               // FI.FileName = "Pizza";
                FI.ShowList(comboBox2);
            }
            else if (comboBox1.SelectedItem.ToString() == "Burger")
            {
                //FI.FileName = "BurgerItems";
                FI.ShowList(comboBox2);
            }
            else if (comboBox1.SelectedItem.ToString() == "Sandwiches")
            {
               // FI.FileName = "SandwichesItems";
                FI.ShowList(comboBox2);
            }
            else if (comboBox1.SelectedItem.ToString() == "Fries")
            {
               // FI.FileName = "FriesItems";
                FI.ShowList(comboBox2);
            }
            else if (comboBox1.SelectedItem.ToString() == "SoftDrinks")
            {
               // FI.FileName = "SoftDrinksitems";
                FI.ShowList(comboBox2);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                COC.AddToCart(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), textBox1.Text, dataGridView1);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select any Item or Quantity");
            }
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

        private void button5_Click(object sender, EventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            

            Random r = new Random();
            int billn = r.Next();
            //COC.QuantityUpdate(dataGridView1);
            COC.FinalizeOrder(dataGridView1,billn);
            
            if (sb == true)
            {
                Form2 f = new Form2(dataGridView1, billn);
                f.Show();
            }
           
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            COC.PriceShow(listBox1,comboBox1.SelectedItem.ToString());
            pictureBox3.Visible = true;
            COC.PicShow(pictureBox3, comboBox1.SelectedItem.ToString());
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }
        }
    }
}
