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
    class AdminControls 
    {
        public void AddUserIDtoCombobox(ComboBox comboBox1)
        {
            Bll_Customer x = new Bll_Customer();
            DataTable dt = x.ShowDetailsForAdmin();
            comboBox1.Items.Add("ALL");
            comboBox1.SelectedItem = "ALL";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i]["ID"].ToString());
            }
        }      
    }

    class Food
    {
        protected string category;

        public string CATEGORY { set { category = value; } }
        
        protected string P_name;
        protected string P_Code;
        protected string Quantity;
        protected string Price;

        public Food()
        {
            
        }
        public Food(string code)
        {
            P_Code = code;
        }
        public Food(string category, string name, string code, string price)
        {
            this.category = category;
            P_name = name;
            P_Code = code;
            Quantity = "50";
            Price = price;
        }
        public Food(string category, string name, string code,string qty, string price)
        {
            this.category = category;
            P_name = name;
            P_Code = code;
            Quantity = qty;
            Price = price;
        }
        
        public void AddFood(DataGridView dgv)
        {
            Bll_Food obj = new Bll_Food();
            obj.AddFood(category, P_name, P_Code, Quantity, Price);
            MessageBox.Show("Item Added");     
        }
        public void UpFood()
        {

            Bll_Food obj = new Bll_Food();

            obj.UpdateFood(category, P_name, P_Code, Quantity, Price);
            MessageBox.Show("Item Updated");

        }

        public void DeleteFood()
        {

            Bll_Food obj = new Bll_Food();

            obj.DeleteFood(P_Code);
            MessageBox.Show("Item Deleted");

        }
        public void ShowFood(DataGridView dgv)
        {
            dgv.Rows.Clear();
            
            Bll_Food show = new Bll_Food();
            DataTable dt = new DataTable();
            dt = show.ShowEmployee(category);

            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string line = "";

                    for (int i = 0; i < 5; i++)
                    {
                        line = line + "," + dt.Rows[j][i].ToString();
                    }
                    string[] values = new string[6];
                    values = line.Split(',');
                    dgv.Rows.Add(values[2], values[3], values[4], values[5], values[5]);
                }
            }

        }
    }

    public class OrderedItems:FoodItems
    {
        int countorders;
        public int COUNTORDERS { get { return countorders; } }
        int burgerCounts ;
        int pizzaCounts ;
        int SoftDrinksCounts ;
        int FriesCount ;
        int SandwichCount ;

        private readonly List<FoodItems> itemss = new List<FoodItems>();

        public void AddItem(FoodItems item)
        {
            itemss.Add(item);
        }

        public int GetTotalCost()
        {
            int cost = 0;
            foreach (FoodItems item in itemss)
            {
                cost += item.Total;
            }
            return cost;
        }

        public OrderedItems()
        {
            burgerCounts = 0;
            pizzaCounts = 0;
            SoftDrinksCounts = 0;
            FriesCount = 0;
            SandwichCount = 0;
        }
        public OrderedItems(string select)
        {
            if (select == "ALL")
            {
                CountNumberofOrders();
            }
            else
            { 
                CountNumberofOrdersforEachUser(select); 
            }
        }
       

        public void CountNumberofOrders()
        {
            Bll_Order ob = new Bll_Order();
            DataTable dt = new DataTable();
            dt = ob.ShowOrderHistory();
            countorders = dt.Rows.Count;

        }

        public void CountNumberofOrdersforEachUser(string user)
        {
            Bll_Order ob = new Bll_Order();
            DataTable dt = new DataTable();
            dt = ob.ShowOrderHistory(user);
            countorders = dt.Rows.Count;
        }

        public void CountEach()
        {
            Bll_Order ob = new Bll_Order();
            DataTable dt = new DataTable();
            dt = ob.ShowOrderHistory();
            countorders = dt.Rows.Count;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["O_Category"].ToString() == "Fries")
                {
                    FriesCount++;
                }
                if (dt.Rows[i]["O_Category"].ToString() == "Burger")
                {
                    burgerCounts++;
                }
                if (dt.Rows[i]["O_Category"].ToString() == "Pizza")
                {
                    pizzaCounts++;
                }
                if (dt.Rows[i]["O_Category"].ToString() == "Sandwiches")
                {
                    SandwichCount++;
                }
                if (dt.Rows[i]["O_Category"].ToString() == "SoftDrinks")
                {
                    SoftDrinksCounts++;
                }
            }
        }
        public void CountEach(string user)
        {
            Bll_Order ob = new Bll_Order();
            DataTable dt = new DataTable();
            dt = ob.ShowOrderHistory(user);
            countorders = dt.Rows.Count;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["O_Category"].ToString() == "Fries")
                {
                    FriesCount++;
                }
                if (dt.Rows[i]["O_Category"].ToString() == "Burger")
                {
                    burgerCounts++;
                }
                if (dt.Rows[i]["O_Category"].ToString() == "Pizza")
                {
                    pizzaCounts++;
                }
                if (dt.Rows[i]["O_Category"].ToString() == "Sandwiches")
                {
                    SandwichCount++;
                }
                if (dt.Rows[i]["O_Category"].ToString() == "SoftDrinks")
                {
                    SoftDrinksCounts++;
                }
            }
        }

        public void ShowCount(Label fries, Label burgers, Label pizza, Label sandwich, Label softdrink)
        {
            fries.Text = FriesCount.ToString();
            burgers.Text = burgerCounts.ToString();
            pizza.Text = pizzaCounts.ToString();
            sandwich.Text = SandwichCount.ToString();
            softdrink.Text = SoftDrinksCounts.ToString();
        }
        
    }

    class Bill
    {
        string billid;
        string cusid;
        string cusname;
        string date;
        string totalamount;
        public Bill() { }
        public Bill(string billid, string cusid, string cusname,string date ,string totalamount)
        {
            this.billid = billid;
            this.cusid = cusid;
            this.cusname = cusname;
            this.date = date;
            this.totalamount = totalamount;
        }
        public Bill(string billid)
        {
            this.billid = billid;
        }

        public void updatebill()
        {
            Bll_Bill update = new Bll_Bill();
            update.UpdateBill(billid, cusid, cusname, date, totalamount);
            MessageBox.Show("Details Updated");
        }
        public void deletebill()
        {
            Bll_Bill delete = new Bll_Bill();
            delete.DeleteBill(billid);
            MessageBox.Show("Details Deleted");
        }
        public void BillShow(string bill, Label Cust_name, Label Date, Label Total)
        {

            Bll_Bill a = new Bll_Bill();
            DataTable dt = new DataTable();
            dt = a.ShowBill(bill);
            //Cust_ID.Text = dt.Rows[0][1].ToString();
            Cust_name.Text = dt.Rows[0][2].ToString();
            Date.Text = dt.Rows[0][3].ToString();
            Total.Text = dt.Rows[0][4].ToString();

        }

        public void BillGetData(DataGridView dgv, DataGridView dgv1) //paisa minus
        {
            OrderedItems oi;
            OrderedItemsBuilder builder = new OrderedItemsBuilder();

            //builder.AddItem();
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                oi = new OrderedItems();
                oi.Name = dgv.Rows[i].Cells[1].Value.ToString();
                oi.Price = Convert.ToInt32(dgv.Rows[i].Cells[2].Value.ToString());
                oi.Qty = Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString());
                oi.Total = Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString());

                builder.AddItem(oi);
                dgv1.Rows.Add(dgv.Rows[i].Cells[1].Value.ToString(), dgv.Rows[i].Cells[2].Value.ToString(), dgv.Rows[i].Cells[3].Value.ToString(), dgv.Rows[i].Cells[4].Value.ToString());
            }
        }
        

        
    }
}
