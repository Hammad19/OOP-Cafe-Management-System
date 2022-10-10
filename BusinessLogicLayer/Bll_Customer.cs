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
        public void RegisterCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal)
        {
            
            DAL obj = new DAL();
            obj.OpenConnection(); 
            obj.LoadSpParameters("sp_insertCust", _ID,  _Fname,  _Lname,  _Gender,  _City,  _Country,  _PhoneNo,  _Email,  _DOB, _Bal);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void UpdateCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updateCust", _ID, _Fname, _Lname, _Gender, _City, _Country, _PhoneNo, _Email, _DOB, _Bal);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public DataTable LoginCustomer(string _ID)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectCust", _ID);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }

      

        public DataTable ShowDetailsForAdmin()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectallCust");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }
    }
}
