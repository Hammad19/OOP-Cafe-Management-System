using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Project
{
    public class FoodItems
    {
        public string Name, Item_Code, FileName;
        public int Qty, Price, Ordered;

        public void ShowList(ComboBox cbx)
        {
            cbx.Items.Clear();
            Bll_Order a = new Bll_Order();
            DataTable dt = new DataTable();
            dt = a.SelectItemFromCat(FileName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbx.Items.Add(dt.Rows[i]["P_Name"].ToString());
            }
            
            /*
            StreamReader sr = new StreamReader(FileName + ".txt", true);
            string[] values = new string[5];

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                values = line.Split(',');
                cbx.Items.Add(values[0]);
            }
            sr.Close();
             */
        }

        public void QuickLink(RadioButton r1,RadioButton r2,RadioButton r3,RadioButton r4,RadioButton r5)
        {
            if (r1.Checked==true)
            {
                Pizza p = new Pizza();
            }
            else if (r2.Checked == true)
            {
                Burger b = new Burger();
            }
            else if (r3.Checked == true)
            {
                Sandwiches sd = new Sandwiches();
            }
            else if (r4.Checked == true)
            {
                Fries f = new Fries();
            }
            else if (r5.Checked == true)
            {
                SoftDrinks sd = new SoftDrinks();
            }
        }

        class Pizza:FoodItems
        {
            public Pizza()
            {
                FormControls.QuickView = "Pizza";
            }
        }

        class Burger : FoodItems
        {
            public Burger()
            {
                FormControls.QuickView = "Burger";
            }
        }

        class Sandwiches : FoodItems
        {
            public Sandwiches()
            {
                FormControls.QuickView = "Sandwiches";
            }
        }

        class Fries : FoodItems
        {
            public Fries()
            {
                FormControls.QuickView = "Fries";
            }
        }

        class SoftDrinks : FoodItems
        {
            public SoftDrinks()
            {
                FormControls.QuickView = "SoftDrinks";
            }
        }
    }
}
