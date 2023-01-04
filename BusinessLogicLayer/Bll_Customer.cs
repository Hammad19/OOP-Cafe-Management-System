using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class Bll_Customer
    {
        ICustomerDataAccess dataAccessLayer;

        public Bll_Customer()
        {
            dataAccessLayer = DataAccessFactory.GetDataAccessObject();
        }

        public void RegisterCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal)
        {

            dataAccessLayer.RegisterCustomer(_ID, _Fname, _Lname, _Gender, _City, _Country, _PhoneNo, _Email, _DOB, _Bal);
        }

        public void UpdateCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal)
        {
            dataAccessLayer.UpdateCustomer(_ID, _Fname, _Lname, _Gender, _City, _Country, _PhoneNo, _Email, _DOB, _Bal);
        }

        public DataTable ShowDetailsForAdmin()
        {
            return dataAccessLayer.ShowDetailsForAdmin();
        }

        public DataTable LoginCustomer(string _ID)
        {
            return dataAccessLayer.LoginCustomer(_ID);
        }
    }

    public interface ICustomerDataAccess
    {
        void RegisterCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal);
        void UpdateCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal);
        DataTable ShowDetailsForAdmin();
        DataTable LoginCustomer(string _ID);
        
    }


    public class CustomerDataAccessAdapter : ICustomerDataAccess
    {
        private DAL dataAccessLayer;

        public CustomerDataAccessAdapter(DAL dataAccessLayer)
        {
            this.dataAccessLayer = dataAccessLayer;
        }

        public void RegisterCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal)
        {
            dataAccessLayer.OpenConnection();
            dataAccessLayer.LoadSpParameters("sp_insertCust", _ID, _Fname, _Lname, _Gender, _City, _Country, _PhoneNo, _Email, _DOB, _Bal);
            dataAccessLayer.ExecuteQuery();
            dataAccessLayer.UnLoadSpParameters();
            dataAccessLayer.CloseConnection();
        }


        public void UpdateCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal)
        {

            dataAccessLayer.OpenConnection();
            dataAccessLayer.LoadSpParameters("sp_updateCust", _ID, _Fname, _Lname, _Gender, _City, _Country, _PhoneNo, _Email, _DOB, _Bal);
            dataAccessLayer.ExecuteQuery();
            dataAccessLayer.UnLoadSpParameters();
            dataAccessLayer.CloseConnection();
        }

        public DataTable LoginCustomer(string _ID)
        {
            DataTable de = new DataTable();
            dataAccessLayer.OpenConnection();
            dataAccessLayer.LoadSpParameters("sp_selectCust", _ID);
            de = dataAccessLayer.GetDataTable();
            dataAccessLayer.UnLoadSpParameters();
            dataAccessLayer.CloseConnection();
            return de;
        }

     
        public DataTable ShowDetailsForAdmin()
        {
            DataTable de = new DataTable();
            dataAccessLayer.OpenConnection();
            dataAccessLayer.LoadSpParameters("sp_selectallCust");
            de = dataAccessLayer.GetDataTable();
            dataAccessLayer.UnLoadSpParameters();
            dataAccessLayer.CloseConnection();
            return de;
        }
    }


    public static class DataAccessFactory
    {
        public static ICustomerDataAccess GetDataAccessObject()
        {
            return new CustomerDataAccessAdapter(new DAL());
        }
    }
}
