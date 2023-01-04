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

        public string GetFileName()
        {
            return FileName;
        }
        public int Qty, Price,Total;

        public FoodItems() { }
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
            
        }
        
    }
    class Pizza : FoodItems
    {
        public Pizza()
        {
            FileName = "Pizza";
            //FormControls.QuickView = "Pizza";
        }
    }

    class Burger : FoodItems
    {
        public Burger()
        {
            FileName = "Burger";
            //FormControls.QuickView = "Burger";
        }
    }

    class Sandwiches : FoodItems
    {
        public Sandwiches()
        {
            FileName = "Sandwiches";
            //FormControls.QuickView = "Sandwiches";
        }
    }

    class Fries : FoodItems
    {
        public Fries()
        {
            FileName = "Fries";
            //FormControls.QuickView = "Fries";
        }
    }

    class SoftDrinks : FoodItems
    {
        public SoftDrinks()
        {
            FileName = "SoftDrinks";
            //FormControls.QuickView = "SoftDrinks";
        }
    }



    public class FoodFactory
    {

        FoodItems food;

        public FoodItems CreateFoodItem(RadioButton r1, RadioButton r2, RadioButton r3, RadioButton r4, RadioButton r5)
        {
           
            if (r1.Checked == true)
            {
                 food = new Pizza();
            }
            else if (r2.Checked == true)
            {
                food = new Burger();
            }
            else if (r3.Checked == true)
            {
                food = new Sandwiches();
            }
            else if (r4.Checked == true)
            {
                food = new Fries();
            }
            else if (r5.Checked == true)
            {
                food = new SoftDrinks();
            }

            return food;

        }

    }


    public interface Builder
    {
        OrderedItems Build();
    }

    public class OrderedItemsBuilder:Builder
    {
        private readonly OrderedItems orderedItems = new OrderedItems();

        public OrderedItemsBuilder AddItem(FoodItems fooditem)
        {
            orderedItems.AddItem(fooditem);
            return this;
        }

        public OrderedItems Build()
        {
            return orderedItems;
        }
    }

}
