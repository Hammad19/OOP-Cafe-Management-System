using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BusinessLogicLayer;
using System.Data;

namespace OOP_Project
{
    class CheckOutCart
    {

        
        public void PicShow(PictureBox pb, string opt)
        {
            switch (opt)
            {
                case "Pizza":
                    pb.ImageLocation = "BFV36537_CC2017_2IngredintDough4Ways-FB.jpg";
                    break;

                case "Burger":
                    pb.ImageLocation = "quesoburgerthumb.jpg";
                    break;

                case "Sandwiches":
                    pb.ImageLocation = "sandwiches.png";
                    break;

                case "Fries":
                    pb.ImageLocation = "Baked-French-Fries-1-200x200.jpg";
                    break;

                case "SoftDrinks":
                    pb.ImageLocation = "P-8f2f7419-a4dc-40db-b151-6781099b10c3_11052018182541.jpg";
                    break;

                default:
                    break;
            }
        }

        public void PriceShow(ListBox lb,string file)
        {

            Bll_Order a = new Bll_Order();
            DataTable dt = new DataTable();
            dt = a.SelectItemFromCat(file);
            lb.Items.Add("Item Name , Price");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lb.Items.Add(dt.Rows[i]["P_Name"].ToString() + "," + dt.Rows[i]["P_Price"].ToString());
            }
            /*
            StreamReader sr = new StreamReader(file + "items.txt", true);
            string line;
            string [] values = new string[4];
            lb.Items.Add("Item Name , Price");
            while ((line = sr.ReadLine())!= null)
            {
                values = line.Split(',');
                lb.Items.Add(values[0] + "," + values[3]);
            }
             */
        }

        

        public void QuantityUpdate(DataGridView dgv)
        {
            Bll_Food food = new Bll_Food();
            DataTable dat = new DataTable();
            Bll_Order a = new Bll_Order();
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {


                dat = a.SelectItemFromCat(dgv.Rows[i].Cells[0].Value.ToString());
                for (int x = 0; x < dat.Rows.Count; x++)
                {
                    if (dat.Rows[x]["P_Name"].ToString() == dgv.Rows[i].Cells[1].Value.ToString())
                    {

                        int qtyminus = 0;
                        qtyminus = Convert.ToInt32(dat.Rows[x]["P_Qty"]) - Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString());
                        if (qtyminus > 0)
                        {
                            food.UpdateFood(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString(), dat.Rows[x]["P_Code"].ToString(), qtyminus.ToString(), dat.Rows[x]["P_Price"].ToString());
                            OrderPlacement.sb = true;
                        }

                        else
                        {
                            MessageBox.Show(dat.Rows[x]["P_Name"].ToString() + " Out of Stock\nTry to Order Smaller Quantity");
                            OrderPlacement.sb = false;
                        }
                    }
                }



            }
        }


        public void FinalizeOrder(DataGridView dgv,int bill_id) //paisa minus
        {
            Bll_Order ord = new Bll_Order();
            Bll_Bill bill = new Bll_Bill();
            Bll_Food food = new Bll_Food();

            QuantityUpdate(dgv);

            if (OrderPlacement.sb == true)
            {
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    double Total_bill_for_Each_Row = 0;
                    Total_bill_for_Each_Row = (Convert.ToDouble(dgv.Rows[i].Cells[2].Value) * Convert.ToDouble(dgv.Rows[i].Cells[3].Value));
                    ord.AddOrder(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString(), dgv.Rows[i].Cells[2].Value.ToString(), dgv.Rows[i].Cells[3].Value.ToString(), Total_bill_for_Each_Row.ToString(), FormControls.Id);
                    
                }
                MessageBox.Show("Order Placed");
                double Total_bill = 0;
                for (int ix = 0; ix < dgv.RowCount - 1; ix++)
                {
                    Total_bill += (Convert.ToDouble(dgv.Rows[ix].Cells[2].Value) * Convert.ToDouble(dgv.Rows[ix].Cells[3].Value));
                }
                DateTime dt = DateTime.Now;
                bill.AddBill(bill_id.ToString(), FormControls.Id, FormControls.Username, Convert.ToString(dt), Total_bill.ToString());
            }
            
            
        }

        

        public void AddToCart(string category,string item,string numm,DataGridView dgv)  //qty minus
        {

            Bll_Order a = new Bll_Order();
            DataTable dt = new DataTable();
            dt = a.SelectItemFromCat(category);
            
            //    lb.Items.Add(dt.Rows[i]["P_Name"].ToString() + "," + dt.Rows[i]["P_Price"].ToString());
            
            MessageBox.Show("Start");

            int qty;
            //int N_qty = 0;
            bool verif = int.TryParse(numm,out qty);

            if (verif==true)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["P_Name"].ToString()==item)
                    {
                        double total = Convert.ToDouble(numm) * Convert.ToDouble(dt.Rows[i]["P_Price"].ToString());
                        dgv.Rows.Add(category, item,  dt.Rows[i]["P_Price"].ToString(), qty, total);
                    }
                }
                
                /*
                StreamReader sr = new StreamReader(category + "items.txt", true);
                string line;
                bool update = true;
                string[] values = new string[4];

                while ((line = sr.ReadLine()) != null)
                {
                    StreamWriter sw = new StreamWriter("temp.txt", true);
                    values = line.Split(',');
                    if (values[0] == item)
                    {
                        Int64 qty_chck = Convert.ToInt64(values[2]);
                        if (qty_chck >= qty)
                        {
                            dgv.Rows.Add(category,item, values[3], qty, qty * Convert.ToInt32(values[3]));
                            N_qty = Convert.ToInt32(values[2]) - qty;
                            sw.WriteLine(values[0] + "," + values[1] + "," + N_qty + "," + values[3]);
                        }
                        else
                        {
                            MessageBox.Show("Quantity Unavaliable. Stock Left = " + values[2]);
                            update = false;
                        }
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
                sr.Close();
                sr.Dispose();
                 */
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

                /*
                if (update == true)
                {
                    File.Delete(category + "items.txt");
                    File.Move("temp.txt", category + "items.txt");
                }
                File.Delete("temp.txt");
                 */
            }

            else
            {
                MessageBox.Show("Enter Numbers only");
            }
           
        }
    }
}
