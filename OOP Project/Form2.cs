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
    public partial class Form2 : Form
    {
        DateTime dt = DateTime.Now;
        DataGridView dgv;
        private int billid = 0; 
        public Form2(DataGridView dagv,int bill_id)
        {
            dgv = dagv;
            billid = bill_id;
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            //CheckOutCart coc = new CheckOutCart();
            Bill cocx = new Bill();
            bill_number.Text = billid.ToString();
            cocx.BillGetData(dgv, dataGridView1);
            cocx.BillShow(billid.ToString(), cosname, bill_date, total);
            bill_date.Text =dt.ToString();
            dgv.Rows.Clear();
        }

        private void bill_date_Click(object sender, EventArgs e)
        {

        }
    }
}
