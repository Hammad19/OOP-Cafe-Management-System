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

    public class CustomerCollection
    {
        private List<Costumer> customer = new List<Costumer>();

        public CustomerIterator GetIterator()
        {
            return new CustomerIterator(customer);
        }

        public void AddCustomer(Costumer customer)
        {
            this.customer.Add(customer);
        }

    }

    public class CustomerIterator
    {
        private List<Costumer> customers;
        public int index;

        public CustomerIterator(List<Costumer> customers)
        {
            this.customers = customers;
            index = 0;
        
        }

        public bool HasNext()
        {
            return index < customers.Count;
        }

        public Costumer Next()
        {
            return customers[index++];
            
        }
    }


    public class User
    {
        string f_name, l_name, gender , city, country, email, date, phone_no;

        public User() { }
        public User(string FirstName,string LastName,string Gender,string City,string Country,string Phone,string Email,string DateOfBirth)
        {
            this.Firstname = FirstName;
            this.Lastname = LastName;
            this.Gender = Gender;
            this.City = City;
            this.Country = Country;
            this.PhoneNumber = Phone;
            this.Email = Email;
            this.Date = DateOfBirth;

        }
        //int pin;
          

        //public int ID
        //{
        //    get { return pin; }
        //    set
        //    {
        //        pin = value;
        //    }
        //}
        public string Firstname
        {
            get { return f_name; }
            set
            {
                f_name = value;
            }
        }
        public string Lastname
        {
            get { return l_name; }
            set { l_name = value;}
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value;}
        }

        public string City
        {
            get { return city; }
            set { city = value;}
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string PhoneNumber
        {
            get { return phone_no; }
            set { phone_no = value; }
        }
        int err = 0, num;
        public static int rand_num,lgnfrm;


        
        
    
    }
        
    public class Costumer:User
        
    {

        private int customerid;
            
        private int balance = 1000 ;

        public Costumer() { }
         public Costumer(string CustomerID,string FirstName,string LastName,string Gender,string City,string Country,string Phone,string Email,string DateOfBirth,string Balance):base(FirstName,LastName,Gender,City,Country,Phone,Email,DateOfBirth)
        {
            this.CustomerID = Convert.ToInt32(CustomerID);
            this.balance = Convert.ToInt32(Balance);
        }

        public int Balance { get { return balance; } set { balance = value; } }
            public int CustomerID
            {
                get { return customerid; }
                set { customerid = value; }
            }

       

        
        public void SetAllData(string idd,string fnamee, string lnamee, RadioButton male, RadioButton female, string cityy, string countryy, string phonenoo, string eemaill, DateTimePicker bbday)
        {
            CustomerID = Convert.ToInt32(idd);
            Firstname = fnamee;
            Lastname = lnamee;
            if (male.Checked)
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }
            City = cityy;
            Country = countryy;
            PhoneNumber = phonenoo;
            Email = eemaill;
            Date = Convert.ToString(bbday.Value);
        
        }

        public void Login()
        {
            
            Bll_Customer login = new Bll_Customer();
            DataTable dt = new DataTable();
            dt = login.LoginCustomer(CustomerID.ToString());
            if (dt.Rows.Count > 0)
            {
                if (CustomerID.ToString() == dt.Rows[0]["ID"].ToString())
                {
                    if (Firstname == dt.Rows[0]["F_Name"].ToString())
                    {
                        Firstname = dt.Rows[0]["F_Name"].ToString();
                        FormControls.updateinfo = "yes";
                        FormControls.Username = Firstname;
                        FormControls.Id = CustomerID.ToString();
                        Home h = new Home();
                        h.Show();
                        lgnfrm = 1;
                    }
                    else { MessageBox.Show("Incorrect User or Password"); }
                }
            }
            else
            {
                MessageBox.Show("Incorrect User or Password");
            }

            /*
            StreamReader sr = new StreamReader("regdata.txt", true);
            string[] values = new string[11];

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                values = line.Split(',');
                if (name == values[1])
                {
                    if (id == values[0])
                    {
                        FormControls.Username = name;
                        FormControls.Id = id;
                        Home h = new Home();
                        h.Show();
                        lgnfrm = 1;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin");
                    }
                }
            }
            sr.Close();
             */
        }

        public void UpdateCostumer()
        {
                            
           //Bll_Customer obj = new Bll_Customer();
           //obj.UpdateCustomer(CustomerID.ToString(), Firstname, Lastname, Gender, City, Country, PhoneNumber, Email, Date, Balance.ToString());
           //FormControls.registrationclose = "Yes";
           //MessageBox.Show("Updation Sucessfull");
                        
        }

        public void Registration()
        {

            Bll_Customer customer = new Bll_Customer();   
            customer.RegisterCustomer(CustomerID.ToString(), Firstname, Lastname, Gender, City, Country, PhoneNumber, Email, Date, Balance.ToString());                   
            FormControls.registrationclose = "Yes";

            MessageBox.Show("Registration Sucessfull");
                     
        }

        public void GetDetails()
        {

            //Firstname = FormControls.Username;
            //CustomerID = Convert.ToInt32(FormControls.Id);
            //Bll_Customer login = new Bll_Customer();
            //DataTable dt = new DataTable();
            //dt = login.LoginCustomer(CustomerID.ToString());
            //if (dt.Rows.Count > 0)
            //{
            //    if (CustomerID.ToString() == dt.Rows[0]["ID"].ToString())
            //    {
            //        if (Firstname == dt.Rows[0]["F_Name"].ToString())
            //        {
            //            CustomerID = Convert.ToInt32(dt.Rows[0]["ID"]);
            //            balance = Convert.ToInt32(dt.Rows[0]["Balance"]);
            //            Firstname = Convert.ToString(dt.Rows[0]["F_Name"]);
            //            Lastname = Convert.ToString(dt.Rows[0]["L_Name"]);
            //            Gender = Convert.ToString(dt.Rows[0]["Gender"]);
            //            Date = Convert.ToString(dt.Rows[0]["DOB"]);
            //            City = Convert.ToString(dt.Rows[0]["City"]);
            //            Country = Convert.ToString(dt.Rows[0]["Country"]);
            //            PhoneNumber = Convert.ToString(dt.Rows[0]["Phone"]);
            //            Email = Convert.ToString(dt.Rows[0]["Email"]);
                      
            //        }
            //    }
            //}
        }

            public void ShowDetails(Label a,Label b,Label c,Label d,Label e,Label f,Label g,Label h,Label i,Label j)
            
            {

                a.Text = "Unique Id Is " + CustomerID.ToString();             
                b.Text = "Remaining Balance " + balance.ToString();           
                c.Text = "First Name " + Firstname;            
                d.Text = "Last Name " + Lastname;
                e.Text = "Gender " + Gender;        
                f.Text = "DOB " + Date;          
                g.Text = "City " + City;          
                h.Text = "Country " + Country;           
                i.Text = "Phone No. " + PhoneNumber;             
                j.Text = "Email " + Email;
                   
            

            /*
            StreamReader sr = new StreamReader("regdata.txt", true);
            string[] values = new string[11];

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                values = line.Split(',');
                if (FormControls.Username == values[1])
                {
                    if (FormControls.Id == values[0])
                    {
                        a.Text = "Unique Id Is " + values[0];
                        b.Text = "Remaining Balance " + values[9];
                        c.Text = "First Name " + values[1];
                        d.Text = "Last Name " + values[2];
                        e.Text = "Gender " + values[3];
                        f.Text = "DOB " + values[8];
                        g.Text = "City " + values[4];
                        h.Text = "Country " + values[5];
                        i.Text = "Phone No. " + values[6];
                        j.Text = "Email " + values[7];
                        break;
                    }
                }
            }
            sr.Close();
             */
        }
            public  void UserHistory(DataGridView dgv, string user)
            {
                Bll_Order search = new Bll_Order();
                DataTable dt = new DataTable();
                dt = search.ShowOrderHistory(user);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv.Rows.Add(dt.Rows[i]["O_Category"].ToString(), dt.Rows[i]["O_Name"].ToString(), dt.Rows[i]["O_UnitPrice"].ToString(), dt.Rows[i]["O_Qty"].ToString(), dt.Rows[i]["O_Total"].ToString());
                }

            }
    }

     sealed class Admin


     {
         private string Adminid;
         public string AdminID
         {
             get { return Adminid; }
             set { Adminid = value; }
         }

         private Admin() { }
         private Admin(string AdminID)
         { this.AdminID = AdminID; }

         private static Admin instance;

         public static Admin GetInstance(string ID)
         {
             if(instance == null)
             {
                 instance = new Admin(ID);
             }
             return instance;

         }


         public  void UserHistory(DataGridView dgv)
         {
             
             Bll_Order search = new Bll_Order();
             DataTable dt = new DataTable();
             dt = search.ShowOrderHistory();

             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 dgv.Rows.Add(dt.Rows[i]["O_Category"].ToString(), dt.Rows[i]["O_Name"].ToString(), dt.Rows[i]["O_UnitPrice"].ToString(), dt.Rows[i]["O_Qty"].ToString(), dt.Rows[i]["O_Total"].ToString());
             }
         }

         public void GetDetails(DataGridView dgv, CustomerCollection customerCollection)
         {
             //Costumer c;
             //Bll_Customer search = new Bll_Customer();
             //DataTable dt = new DataTable();
             //dt = search.ShowDetailsForAdmin();

             //for (int i = 0; i < dt.Rows.Count; i++)
             //{
             //    c = new Costumer(dt.Rows[i]["ID"].ToString(), dt.Rows[i]["F_Name"].ToString(), dt.Rows[i]["L_Name"].ToString(), dt.Rows[i]["Gender"].ToString(), dt.Rows[i]["City"].ToString(), dt.Rows[i]["Country"].ToString(), dt.Rows[i]["Phone"].ToString(), dt.Rows[i]["Email"].ToString(), dt.Rows[i]["DOB"].ToString(), dt.Rows[i]["Balance"].ToString());
             //    customerCollection.AddCustomer(c);

             //}

         }


         public void ShowDetails(DataGridView dgv)
         {
             Costumer c;
             CustomerCollection customerCollection = new CustomerCollection();
             GetDetails(dgv, customerCollection);
             CustomerIterator customeriterator = customerCollection.GetIterator();
             while (customeriterator.HasNext())
             {
                 c = customeriterator.Next();
                 dgv.Rows.Add(c.CustomerID.ToString(), c.Firstname, c.Lastname, c.Gender, c.City, c.Country, c.PhoneNumber, c.Email, c.Date, c.Balance);
             }
         }

         public void ShowBill(DataGridView dgv)
         {
             Bll_Bill search = new Bll_Bill();
             DataTable dt = new DataTable();
             dt = search.ShowBill();

             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 dgv.Rows.Add(dt.Rows[i]["Bill_ID"].ToString(), dt.Rows[i]["CUS_ID"].ToString(), dt.Rows[i]["CUS_NAME"].ToString(), dt.Rows[i]["Bill_Date"].ToString(), dt.Rows[i]["Bill_AMOUNT"].ToString());
             }
         }

         public void ShowBill(DataGridView dgv,string customerid)
         {
             
             Bll_Bill search = new Bll_Bill();
             DataTable dt = new DataTable();
             dt = search.BillsWithResToCustomer(customerid);

             for (int i = 0; i < dt.Rows.Count; i++)
             {

                 dgv.Rows.Add(dt.Rows[i]["Bill_ID"].ToString(), dt.Rows[i]["CUS_ID"].ToString(), dt.Rows[i]["CUS_NAME"].ToString(), dt.Rows[i]["Bill_Date"].ToString(), dt.Rows[i]["Bill_AMOUNT"].ToString());
             }
         } 
     }
}
