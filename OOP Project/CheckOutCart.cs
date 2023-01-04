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
            //Builder Pattern
            FoodItems oi;
            OrderedItemsBuilder builder = new OrderedItemsBuilder();
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
                    oi = new FoodItems();
                    oi.Name = dgv.Rows[i].Cells[1].Value.ToString();
                    oi.Price = Convert.ToInt32(dgv.Rows[i].Cells[2].Value.ToString());
                    oi.Qty = Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString());
                    oi.Total = Convert.ToInt32(Total_bill_for_Each_Row.ToString());
                    builder.AddItem(oi);
                }
                MessageBox.Show("Order Placed");


                OrderedItems OrderedItem = builder.Build();

                int Total_bill = OrderedItem.GetTotalCost();
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
                
         
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }

            else
            {
                MessageBox.Show("Enter Numbers only");
            }
           
        }
    }
}
